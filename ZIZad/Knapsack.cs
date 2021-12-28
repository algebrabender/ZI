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

        public bool blockMode;
        private int counter;
        private byte[] nonce;

        private TigerHash tigerHash;

        #endregion

        public Knapsack()
        {
            //korisice se polu rec da mi mogli da se kodiraju i nasa slova, odnosno karakteri koji su veci od jednog bajta 
            P = new long[16];
            J = new long[16];
            counter = 0;
            nonce = new byte[2];

            tigerHash = new TigerHash();
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

            string oneLine = "";
            counter = 0;
            foreach (var item in plaintextLines)
            {
                oneLine += item + "\n";
                string plaintext = "";
                byte[] charsInBytes = Encoding.Unicode.GetBytes(item.ToCharArray());
                BitArray B;
                for (int c = 0; c < charsInBytes.Length - 1; c += 2)
                {
                    long C = 0;
                    if (!blockMode)
                    {
                        int len;
                        if (charsInBytes[c + 1] == (byte)0)
                            len = 8;
                        else
                            len = 16;
                        B = new BitArray(new byte[] { charsInBytes[c], charsInBytes[c + 1] });
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
                    else
                    {
                        BitArray nonceInBits = new BitArray(nonce);
                        BitArray counterInBits = new BitArray(new byte[] { (byte)counter, (byte)0 });
                        nonceInBits.Xor(counterInBits);
                        for (int i = 15; i >= 0; i--)
                        {
                            int b = nonceInBits[i] ? 1 : 0;
                            Console.WriteLine(nonceInBits[i]);
                            if (b == 0)
                                continue;
                            C += J[i] * b;
                        }
                        BitArray encryptedCharInBits;
                        byte[] CinBytes = BitConverter.GetBytes(C);
                        encryptedCharInBits = new BitArray(CinBytes);
                        B = new BitArray(new byte[] { charsInBytes[c], charsInBytes[c + 1], 0, 0, 0, 0, 0, 0 });
                        encryptedCharInBits.Xor(B);
                        byte[] encryptedChar = new byte[8];
                        encryptedCharInBits.CopyTo(encryptedChar, 0);

                        plaintext += BitConverter.ToInt32(encryptedChar, 0) + " ";

                        counter++;
                    }
                }
                encryptedLines.Add(plaintext);
            }

            tigerHash.Preprocess(oneLine);
            byte[] hashedText = tigerHash.Process();
            string temp = Encoding.Unicode.GetString(hashedText);
            encryptedLines.Add(temp);

            return encryptedLines;
        }

        public List<string> Decrypt(string filePath, out bool sameHashes)
        {
            sameHashes = false;

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
            string oneLine = "";
            counter = 0;

            for (int j = 0; j < plaintextLines.Count - 1; j++)
            {
                plaintext = "";
                string[] chars = plaintextLines[j].Split(' ');
                foreach (string C in chars)
                {
                    if (C == "")
                        continue;
                    if (!blockMode)
                    {
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
                    else
                    {
                        long c = 0;
                        BitArray nonceInBits = new BitArray(nonce);
                        BitArray counterInBits = new BitArray(new byte[] { (byte)counter, (byte)0 });
                        nonceInBits.Xor(counterInBits);
                        for (int i = 15; i >= 0; i--)
                        {
                            int b = nonceInBits[i] ? 1 : 0;
                            Console.WriteLine(nonceInBits[i]);
                            if (b == 0)
                                continue;
                            c += J[i] * b;
                        }
                        BitArray encryptedNonce;
                        byte[] encryptedNonceinBytes = BitConverter.GetBytes(c);
                        encryptedNonce = new BitArray(encryptedNonceinBytes);
                        int encryptedChar = Int32.Parse(C);
                        byte[] encryptedCharInBytes = BitConverter.GetBytes(encryptedChar);
                        BitArray B;
                        B = new BitArray(new byte[] { encryptedCharInBytes[0], encryptedCharInBytes[1], 0, 0, 0, 0, 0, 0 });
                        encryptedNonce.Xor(B);
                        byte[] decryptedChar = new byte[8];
                        encryptedNonce.CopyTo(decryptedChar, 0);

                        plaintext += BitConverter.ToChar(decryptedChar, 0);

                        counter++;
                    }
                }
                oneLine += plaintext + "\n";
                decryptedLines.Add(plaintext);
            }

            tigerHash.Preprocess(oneLine);
            byte[] hashedText = tigerHash.Process();
            string temp = Encoding.Unicode.GetString(hashedText);
            string hashedFromFile = plaintextLines[plaintextLines.Count - 1];
            if (temp == hashedFromFile)
                sameHashes = true;

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

            random.NextBytes(nonce);

            if (!Directory.Exists("Keys"))
                Directory.CreateDirectory("Keys");

            string filePath = "Keys\\" + fileName;

            using (StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {

                foreach (int i in J)
                {
                    sw.Write(i + " ");
                }
                sw.WriteLine();
                foreach (int i in P)
                {
                    sw.Write(i + " ");
                }
                sw.WriteLine();
                sw.WriteLine(n);
                sw.WriteLine(im);
                sw.Write(String.Concat(nonce.Select(x => x.ToString("X2")).ToArray()));
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
                    Int64.TryParse(item, out J[i++]);
                }
                readLine = sr.ReadLine();
                i = 0;
                foreach (var item in readLine.Split(' '))
                {
                    if (item == "")
                        continue;
                    Int64.TryParse(item, out P[i++]);
                }
                Int64.TryParse(sr.ReadLine(), out n);
                Int64.TryParse(sr.ReadLine(), out im);
                string hex = sr.ReadLine();
                nonce = Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
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
