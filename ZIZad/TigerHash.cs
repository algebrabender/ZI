using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIZad
{
    internal class TigerHash
    {
        SBoxes sbox;
        ulong h0;
        ulong h1;
        ulong h2;
        List<byte[]> chunksOf512bits;

        public TigerHash()
        {
            sbox = new SBoxes();
            Initialize();
        }

        private void Initialize()
        {
            h0 = 0x0123456789ABCDEF;
            h1 = 0xFEDCBA9876543210;
            h2 = 0xF096A5B4C3D2E187;
        }
        
        private void Preprocess(string message)
        {
            chunksOf512bits = new List<byte[]>();
            Initialize();

            byte[] messageInBytes = Encoding.Unicode.GetBytes(message);
            int len = messageInBytes.Length;
            int numOfBits = len * 8;
            byte[] newMessageInBytes = new byte[len + (64 - len % 64)]; 

            for (int i = 0; i < messageInBytes.Length; i++)
            {
                newMessageInBytes[i] = messageInBytes[i];
            }

            newMessageInBytes[messageInBytes.Length] = 0x80; //append "1" bit to message

            for (int i = messageInBytes.Length + 1; i < newMessageInBytes.Length - 8; i++)
            {
                newMessageInBytes[i] = 0; //append "0" bits until message length in bits ≡ 448(mod 512)
            }

            byte[] word64 = BitConverter.GetBytes((long)(numOfBits)); //to bytes
            for (int i = 0; i < 8; i++)
            {
                newMessageInBytes[newMessageInBytes.Length - 9 + i] = word64[i];
            }

            for (int i = 0; i < newMessageInBytes.Length / 64; i++)
            {
                byte[] chunk = new byte[64];
                Array.Copy(newMessageInBytes, i * 64, chunk, 0, 64);
                chunksOf512bits.Add(chunk);
            }
        }

        public byte[] Process(string message)
        {
            Preprocess(message);

            foreach (byte[] chunk in chunksOf512bits)
            {
                ulong a = h0;
                ulong b = h1;
                ulong c = h2;

                for (int i = 0; i < 4; i++)
                {
                    ulong[] w = new ulong[8];

                    for (int j = 0; j < 8; j++)
                    {
                        w[j] = BitConverter.ToUInt64(chunk, j * 8);
                        c = c ^ w[j];
                        a = a - (sbox.S0[(byte)c >> 0] ^ sbox.S1[(byte)c >> 16] ^ sbox.S2[(byte)c >> 32] ^ sbox.S3[(byte)c >> 48]);
                        b = b + (sbox.S3[(byte)c >> 8] ^ sbox.S2[(byte)c >> 24] ^ sbox.S1[(byte)c >> 40] ^ sbox.S3[(byte)c >> 56]);
                        b = b * (ulong)(i + 1);

                    }

                    if (i == 0)
                    {
                        w[0] = w[0] - (w[7] ^ 0xA5A5A5A5A5A5A5A5);
                        w[1] = w[1] ^ w[0];
                        w[2] = w[2] + w[1];
                        w[3] = w[3] - (w[2] ^ ((w[1] ^ 0xFFFFFFFFFFFFFFFF) << 19));
                        w[4] = w[4] ^ w[3];
                        w[5] = w[5] + w[4];
                        w[6] = w[6] - (w[5] ^ ((w[4] ^ 0xFFFFFFFFFFFFFFFF) >> 23));
                        w[7] = w[7] ^ w[6];
                    }
                    else if (i == 1)
                    {
                        w[0] = w[0] + w[7];
                        w[1] = w[1] - (w[0] ^ ((w[0] ^ 0xFFFFFFFFFFFFFFFF) << 19));
                        w[2] = w[2] ^ w[1];
                        w[3] = w[3] + w[2];
                        w[4] = w[4] - (w[3] ^ ((w[2] ^ 0xFFFFFFFFFFFFFFFF) >> 23));
                        w[5] = w[5] ^ w[4];
                        w[6] = w[6] + w[5];
                        w[7] = w[7] - (w[6] ^ 0x0123456789ABCDEF);
                    }
                }

                h0 = h0 + a;
                h1 = h1 + b;
                h2 = h2 + c;
            }

            byte[] digest = new byte[24];
            Array.Copy(BitConverter.GetBytes(h0), 0, digest, 0, 8);
            Array.Copy(BitConverter.GetBytes(h1), 0, digest, 8, 8);
            Array.Copy(BitConverter.GetBytes(h2), 0, digest, 16, 8);

            return digest;
        }
    }
}
