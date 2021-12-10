using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZIZad
{
    internal class Knapsack : ICryptoAlgorithm
    {
        #region Attributes

        private long[] P; //deo privatnog kljuca
        private long n; //deo privatnog kljuca
        private long m;
        private long[] J; //javni kljuc
        private long im; //deo privatnog kljuca

        #endregion

        public Knapsack()
        {
            //korisice se polu rec da mi mogli da se kodiraju i nasa slova, odnosno karakteri koji su veci od jednog bajta 
            P = new long[16];
            J = new long[16];
        }

        #region Methodes

        public List<string> Encrypt(string filePath)
        {
            string[] splited = filePath.Split('\\');
            string fileName = splited[splited.Length - 1].Replace(".txt", "PrivateKey.txt");
            this.GenerateAndSaveKey(fileName);

            List<string> plaintextLines = new List<string>();
            List<string> encryptedLines = new List<string>();

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

            foreach (var item in plaintextLines)
            {
                string plaintext = "";
                byte[] charsInBytes = Encoding.Unicode.GetBytes(item.ToCharArray());
                BitArray B;
                for (int c = 0; c < charsInBytes.Length - 1; c += 2)
                {
                    long C = 0;
                    int len;
                    if (charsInBytes[c + 1] == (byte)0)
                        len = 8;
                    else
                        len = 16;
                    B = new BitArray(new byte[] { charsInBytes[c], charsInBytes[c+1] });
                    for (int i = len - 1; i >= 0; i--)
                    {
                        int b = B[i] ? 1 : 0;
                        Console.WriteLine(B[i]);
                        if (b == 0)
                            continue;
                        C += J[i] * b;
                    }
                    plaintext += C.ToString() + " ";
                }
                encryptedLines.Add(plaintext);
            }

            return encryptedLines;
        }

        public List<string> Decrypt(string filePath)
        {
            string[] splited = filePath.Split('\\');
            string fileName = splited[splited.Length - 1];
            this.LoadKey(fileName);
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

            long TC;
            string plaintext = "";
            List<string> decryptedLines = new List<string>();

            foreach (var item in plaintextLines)
            {
                plaintext = "";
                string[] chars = item.Split(' ');
                foreach (string C in chars)
                {
                    if (C == "")
                        continue;
                    TC = 0;
                    TC = (Int32.Parse(C) * im) % n;
                    if (TC < 0)
                        TC += n;

                    List<bool> factors;
                    factors = new List<bool>();
                    factors = this.Factors(TC);
                    BitArray bits = new BitArray(Enumerable.Reverse(factors).ToArray());
                    byte[] b = new byte[2];
                    bits.CopyTo(b, 0);
                    char c = BitConverter.ToChar(b, 0);
                    plaintext += c;
                }

                decryptedLines.Add(plaintext);
            }

            return decryptedLines;
        }

        public void GenerateAndSaveKey(string fileName)
        {
            int temp = 0;
            Random random = new Random();
            for (int i = 0; i < 16; i++)
            {
                temp += random.Next(temp + 1, temp + 3); //da bi se izbegli veliki brojevi
                P[i] = temp;
            }

            n = random.Next(temp, temp + 3); //da bi se izbegli veliki brojevi

            temp = random.Next(1, (int)n/2); //da bi se izbegli veliki brojevi
            while (this.GCD(n, temp) != 1)
                temp = random.Next(1, (int)n/2);
            m = temp;

            for (int i = 0; i < 16; i++)
            {
                J[i] = (P[i] * m) % n;
                if (J[i] < 0)
                    J[i] += n;
            }

            im = this.ModInverse(m, n);

            if (!Directory.Exists("Keys"))
                Directory.CreateDirectory("Keys");

            string filePath = "Keys\\" + fileName;

            using (StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                foreach (int i in P)
                {
                    sw.Write(i + " ");
                }
                sw.WriteLine();
                sw.WriteLine(n);
                sw.Write(im);
            }
        }

        public void LoadKey(string fileName)
        {
            if (fileName.Contains("Encrypted.txt"))
            {
                fileName = fileName.Replace(" Encrypted.txt", "PrivateKey.txt");
            }
            else
            {
                this.GenerateAndSaveKey(fileName);
                return;
            }

            string filePath = "Keys\\" + fileName;

            using (StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                string readLine = sr.ReadLine();
                int i = 0;
                foreach (var item in readLine.Split(' '))
                {
                    if (item == "")
                        continue;
                    Int64.TryParse(item, out P[i++]);
                }
                Int64.TryParse(sr.ReadLine(), out n);
                Int64.TryParse(sr.ReadLine(), out im);
            }
        }

        private long GCD(long a, long b)
        {
            long temp;
            
            while (b != 0)
            {
                temp = a;
                a = b;
                b = temp % b;
            }

            return a;
        }

        private long ModInverse(long  m, long n)
        {
            long n0 = n;
            long y = 0;
            long x = 1;

            if (n == 1)
                return 0;

            while (m > 1)
            {
                long q = m / n;
                long t = n;
                n = m % n;
                m = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += n0;

            return x;
        }

        private List<bool> Factors(long number)
        {
            List<bool> factors = new List<bool>();

            for (int i = 15; i >= 0; i--)
            {
                if (number - P[i] >= 0)
                {
                    factors.Add(true);
                    number -= P[i];
                }
                else
                    factors.Add(false);
            }

            return factors;
        }

        #endregion
    }
}
