using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIZad
{
    internal class Knapsack : ICryptoAlgorithm
    {
        #region Attributes

        private int[] P; //deo privatnog kljuca
        private int n; //deo privatnog kljuca
        private int m;
        private int[] J; //javni kljuc
        private int im; //deo privatnog kljuca

        #endregion

        public Knapsack()
        {
            P = new int[16];
            J = new int[16];
            this.GenerateAndSaveKey("");
            List<byte[]> charsInBytes;
            this.StepOneEncrypt("seulgi", out charsInBytes);
            List<int> temp;
            this.StepTwoEncrypt(charsInBytes, out temp);
            List<int> temp2;
            this.StepOneDecrypt(temp, out temp2);
            List<byte[]> charsInBytes2;
            this.StepTwoDecrypt(temp2, out charsInBytes2);
        }

        #region Methodes

        private void StepOneEncrypt(string line, out List<byte[]> charsInBytes)
        {
            charsInBytes = new List<byte[]>();
            
            foreach (var item in line)
               charsInBytes.Add(BitConverter.GetBytes(item));
        }

        private void StepTwoEncrypt(List<byte[]> charsInBytes, out List<int> encryptedValues)
        {
            encryptedValues = new List<int>();

            int C = 0;
            BitArray B;
            foreach (var c in charsInBytes)
            {
                B = new BitArray(c);
                for (int i = 0; i < B.Length; i++)
                {
                    int b = B[i] ? 1 : 0;
                    C += J[i] * b;
                }
                encryptedValues.Add(C);
            }
        }

        private void StepOneDecrypt(List<int> encryptedValues, out List<int> TCs)
        {
            TCs = new List<int>();
            int TC = 0;
            foreach (var C in encryptedValues)
            {
                TC = (C * im) % n;
                TCs.Add(TC);
            }
        }

        private void StepTwoDecrypt(List<int> TCs, out List<byte[]> charsInBytes)
        {
            charsInBytes = new List<byte[]>();
            List<bool> factors;

            foreach (var TC in TCs)
            {
                //FACTORING NOT WORKING WELL
                factors = new List<bool>();
                factors = this.Factor(TC);
                BitArray bits = new BitArray(factors.ToArray());
                byte[] b = new byte[2];
                bits.CopyTo(b, 0);
                char c = BitConverter.ToChar(b, 0);
                Console.WriteLine(c);
            }
        }

        public List<string> Encrypt(string filePath)
        {
            string[] splited = filePath.Split('\\');
            string fileName = splited[splited.Length - 1].Replace(".txt", "KeySquare.txt");
            this.LoadKey(fileName);

            List<string> plaintextLines = new List<string>();
            List<string> encryptedLines = new List<string>();

            foreach (var item in plaintextLines)
            {
                List<byte[]> charsInBytes;
                this.StepOneEncrypt(item, out charsInBytes);

            }

            return encryptedLines;
        }

        public List<string> Decrypt(string filePath)
        {
            throw new NotImplementedException();
        }

        public void GenerateAndSaveKey(string fileName)
        {
            int temp = 1;
            int sum = 0;
            Random random = new Random();
            for (int i = 0; i < 16; i++)
            {
                temp += random.Next(temp, (int)(temp * 1.5)); //tentative
                P[i] = temp;
                sum += temp;
            }

            n = random.Next(sum, sum * 2); //tentative

            temp = random.Next(1, n);
            while (this.GCD(n, temp) != 1)
                temp = random.Next(1, n);
            m = temp;

            for (int i = 0; i < 16; i++)
            {
                J[i] = (P[i] * m) % n;
            }

            im = this.ModInverse(m, n);
        }

        public void LoadKey(string fileName)
        {
            throw new NotImplementedException();
        }

        private int GCD(int a, int b)
        {
            int temp;
            
            while (b != 0)
            {
                temp = a;
                a = b;
                b = temp % b;
            }

            return a;
        }

        private int ModInverse(int m, int n)
        {
            int n0 = n;
            int y = 0;
            int x = 1;

            if (n == 1)
                return 0;

            while (m > 1)
            {
                int q = m / n;
                int t = n;
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

        private List<bool> Factor(int number)
        {
            //NOT WORKING WELL
            List<bool> factors = new List<bool>();
            
            for (int i = 15; i >= 0; i--)
            {
                if (number - P[i] > 0)
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
