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

        //TODO: USE DIFFERENT KEYSQUARE
        private char[,] keySquare = new char[,] { {'p', 'h', 'q', 'g', 'm'},
                                                  {'e', 'a', 'y', 'l', 'n'},
                                                  {'o', 'f', 'd', 'x', 'k'},
                                                  {'r', 'c', 'v', 's', 'z'},
                                                  {'w', 'b', 'u', 't', 'i'}};
        private int period = 5;

        #endregion

        public Bifid()
        {
            this.Encrypt(null);
        }

        #region Methodes

        private void stepOneEncrypt(string plaintext, out string[] values)
        {
            values = new string[2]; //values[0] - row, values[1] - col

            foreach (var item in plaintext)
            {
                if (item == ' ')
                {
                    values[0] += " ";
                    values[1] += " ";
                    continue;
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (keySquare[i, j] == item)
                        {
                            values[0] += (i + 1).ToString();
                            values[1] += (j + 1).ToString();
                        }
                    }
                }
            }
            Console.WriteLine(values[0]);
            Console.WriteLine(values[1]);
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

            Console.WriteLine(values[0]);
            Console.WriteLine(values[1]);
        }

        private void stepThreeEncrypt(string[] values, out string newValue)
        {
            newValue = "";
            string[] rows = values[0].Split(' ');
            string[] cols = values[1].Split(' ');

            for (int i = 0; i < rows.Length; i++)
                newValue += rows[i] + cols[i] + " ";

            Console.WriteLine(newValue);
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

            Console.WriteLine(encryptedPlaintext);
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

            Console.WriteLine(newValue);
        }

        private void stepTwoDecrypt(string newValue, out string value)
        {
            value = "";
            bool found = false;

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
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        found = false;
                        break;
                    }
                }
            }

            Console.WriteLine(value);
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

            Console.WriteLine(values[0]);
            Console.WriteLine(values[1]);
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

            Console.WriteLine(plaintext);
        }

        public void Encrypt(FileInfo file)
        {
            //TODO: CHECK FOR STRING LENGTH

            string temp = "defend the east wall of the castle";
            string[] values;
            string temp2;
            string temp3;

            this.stepOneEncrypt(temp, out values);
            this.stepTwoEncrypt(values);
            this.stepThreeEncrypt(values, out temp2);
            this.stepFourEncrypt(temp2, out temp3);

            Console.WriteLine("-----------------------------------------------");

            this.Decrypt(temp3);
        }

        public void Decrypt(FileInfo file)
        {

            //TODO
        }

        public void Decrypt(string temp)
        {
            string[] values;
            string temp2;
            string temp3;
            string plaintext;

            this.stepOneDecrypt(temp, out temp2);
            this.stepTwoDecrypt(temp2, out temp3);
            this.stepThreeDecrypt(temp3, out values);
            this.stepFourDecrypt(values, out plaintext);
        }

        #endregion
    }
}
