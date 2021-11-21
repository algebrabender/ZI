using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZIZad
{
    internal class Bifid
    {
        #region Attributes

        private char[,] keySquare = new char[5, 5];
        private int period = 5;
        private int iIndexI; //da bi se smanjilo pretrazivanje
        private int iIndexJ;

        #endregion

        public Bifid()
        { }

        #region Methodes

        private void LoadKeySquareAndPeriod(string fileName)
        {
            if (fileName.Contains("Encrypted"))
                fileName = fileName.Replace(" Encrypted", "");
            if (fileName.Contains("Decrypted"))
                fileName = fileName.Replace(" Decrypted", "");

            string filePath = "Key Squares\\" + fileName;


            if (!File.Exists(filePath))
            {
                this.GenerateAndSaveKeySquareAndPeriod(fileName);
                return;
            }

            using (StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                string readLine = sr.ReadLine();
                int i = 0;
                int j = 0;

                while (i < 5)
                {
                    foreach (var item in readLine)
                    {
                        if (item == 'i')
                        {
                            iIndexI = i;
                            iIndexJ = j;
                        }
                        keySquare[i, j++] = item;
                    }
                    i++;
                    j = 0;
                    readLine = sr.ReadLine();
                }
            }

        }

        private void GenerateAndSaveKeySquareAndPeriod(string fileName)
        {
            if (!Directory.Exists("Key Squares"))
                Directory.CreateDirectory("Key Squares");

            string filePath = "Key Squares\\" + fileName;

            using (StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                Random rand = new Random();
                List<char> showedLetters = new List<char>();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int charNumb = rand.Next(97, 123);
                        char letter = Convert.ToChar(charNumb);
                        if (letter == 'i' && !showedLetters.Contains(letter))
                        {
                            iIndexI = i;
                            iIndexJ = j;
                        }
                        if (letter == 'j' || showedLetters.Contains(letter))
                        {
                            j--;
                            continue;
                        }

                        showedLetters.Add(letter);
                        keySquare[i, j] = letter;

                        sw.Write(letter);
                    }

                    sw.WriteLine();
                }
            }
        }

        private void stepOneEncrypt(string plaintext, out string[] values)
        {
            values = new string[2]; //values[0] - row, values[1] - col
            bool foundLetter = false;

            foreach (var item in plaintext)
            {
                if (item == ' ')
                {
                    values[0] += " ";
                    values[1] += " ";
                    continue;
                }

                if (!Char.IsLetter(item)) //ignorisanje bilo kog drugog znaka ili broja
                    continue;

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (item == 'j')
                        {
                            values[0] += (iIndexI + 1).ToString();
                            values[1] += (iIndexJ + 1).ToString();

                            foundLetter = true;
                            break;
                        }
                        else if (keySquare[i, j] == item)
                        {
                            values[0] += (i + 1).ToString();
                            values[1] += (j + 1).ToString();

                            foundLetter = true;
                            break;
                        }
                    }                
                    if (foundLetter)
                    {
                        foundLetter = false;
                        break;
                    }
                }
            }
        }

        private void stepTwoEncrypt(string[] values)
        {
            string[] trimmedValues = new string[2];
            trimmedValues[0] = values[0].Replace(" ", "");
            trimmedValues[1] = values[1].Replace(" ", "");

            int length = trimmedValues[0].Length;
            int temp = length;
            values[0] = "";
            values[1] = "";
            int k = 0;
            while ((length - period) >= 0)
            {
                values[0] += trimmedValues[0].Substring(period * k, period);
                values[0] += " ";
                values[1] += trimmedValues[1].Substring(period * k, period);
                values[1] += " ";
                k++;
                length -= period;
            }
            values[0] += trimmedValues[0].Substring(temp - length);
            values[1] += trimmedValues[1].Substring(temp - length);
        }

        private void stepThreeEncrypt(string[] values, out string newValue)
        {
            newValue = "";
            string[] rows = values[0].Split(' ');
            string[] cols = values[1].Split(' ');

            for (int i = 0; i < rows.Length; i++)
                newValue += rows[i] + cols[i] + " ";
        }

        private void stepFourEncrypt(string newValue, out string encryptedPlaintext)
        {
            encryptedPlaintext = "";

            for (int i = 0; i < newValue.Length - 2; i += 2)
            {
                if (newValue[i] == ' ')
                {
                    //encryptedPlaintext += " ";
                    i++;
                }
                encryptedPlaintext += keySquare[Int32.Parse(newValue[i].ToString()) - 1, Int32.Parse(newValue[i+1].ToString()) - 1];
            }
        }

        private void stepOneDecrypt(string encryptedPlaintext, out string newValue)
        {
            newValue = "";
            int length = encryptedPlaintext.Length;
            int temp = length;
            int k = 0;
            while ((length - period) >= 0)
            {
                newValue += encryptedPlaintext.Substring(period * k, period);
                newValue += " ";
                k++;
                length -= period;
            }
            newValue += encryptedPlaintext.Substring(temp - length);
        }

        private void stepTwoDecrypt(string newValue, out string value)
        {
            value = "";
            bool foundLetter = false;

            for(int k = 0; k < newValue.Length; k++)
            { 
                if (newValue[k] == ' ')
                {
                    continue;
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (newValue[k] == keySquare[i, j])
                        {
                            value += (i + 1).ToString() + (j + 1).ToString();
                            foundLetter = true;
                            break;
                        }
                    }
                    if (foundLetter)
                    {
                        foundLetter = false;
                        break;
                    }
                }
            }
        }

        private void stepThreeDecrypt(string value, out string[] values)
        {
            values = new string[2];
            int length = value.Length;
            int temp = length;
            int k = 0;

            while ((length - period * 2) >= 0)
            {
                values[0] += value.Substring(period * k, period);
                values[1] += value.Substring(period * (k + 1), period);
                k += 2;
                length -= period * 2;
            }
            values[0] += value.Substring(temp - length, length / 2);
            values[1] += value.Substring(temp - length / 2, length / 2);
        }

        private void stepFourDecrypt(string[] values, out string plaintext)
        {
            plaintext = "";

            for (int i = 0; i < values[0].Length; i++)
            {
                int row = Int32.Parse(values[0][i].ToString()) - 1;
                int col = Int32.Parse(values[1][i].ToString()) - 1;

                plaintext += keySquare[row, col];
            }
        }

        public List<string> Encrypt(string filePath)
        {
            string[] splited = filePath.Split('\\');
            string fileName = splited[splited.Length - 1].Replace(".txt", "KeySquare.txt");
            this.LoadKeySquareAndPeriod(fileName);

            List<string> plaintextLines = new List<string>();

            //u slucaju ponovnog otvaranja kroz fsw nakon nekog vremena
            using (StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                string line = sr.ReadLine();
                while (!String.IsNullOrEmpty(line))
                {
                    plaintextLines.Add(line);
                    line = sr.ReadLine();
                }
            }

            string[] rcValues;
            string rcTogether;
            List<string> encryptedLines = new List<string>();

            foreach (var item in plaintextLines)
            {
                string temp;
                this.stepOneEncrypt(item.ToLower(), out rcValues);
                this.stepTwoEncrypt(rcValues);
                this.stepThreeEncrypt(rcValues, out rcTogether);
                this.stepFourEncrypt(rcTogether, out temp);
                encryptedLines.Add(temp);
            }

            return encryptedLines;
        }

        public List<string> Decrypt(string filePath)
        {
            string[] splited = filePath.Split('\\');
            string fileName = splited[splited.Length - 1].Replace(".txt", "KeySquare.txt");
            this.LoadKeySquareAndPeriod(fileName);

            List<string> plaintextLines = new List<string>();

            //u slucaju ponovnog otvaranja kroz fsw nakon nekog vremena
            using (StreamReader sr = new StreamReader((new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))))
            {
                string line = sr.ReadLine();
                while (!String.IsNullOrEmpty(line))
                {
                    plaintextLines.Add(line);
                    line = sr.ReadLine();
                }
            }

            string temp2;
            string temp3;
            string[] values;
            string plaintext;
            List<string> decryptedLines = new List<string>();

            foreach (var item in plaintextLines)
            {
                this.stepOneDecrypt(item, out temp2);
                this.stepTwoDecrypt(temp2, out temp3);
                this.stepThreeDecrypt(temp3, out values);
                this.stepFourDecrypt(values, out plaintext);
                decryptedLines.Add(plaintext);
            }

            return decryptedLines;
        }

        #endregion
    }
}
