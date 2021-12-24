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
        byte[] message;

        public TigerHash()
        {
            sbox = new SBoxes();
            h0 = 0x0123456789ABCDEF;
            h1 = 0xFEDCBA9876543210;
            h2 = 0xF096A5B4C3D2E187;
        }

        private void Preprocess(byte[] message)
        {
            //svodjenje na umnozak od 512 bitova
        }

        private void Process()
        {
            
            //za svaki od 512 chunk poruke podeliti segment na 8 64bitnih bigendia reci w[i], i = [0, 7]
                //ulong a = h0;
                //ulong b = h1;
                //ulong c = h2;
                
                //glavna petlja - za i = [0, 3]
                    //za svaku rundu u okviru grupe -> za j = [0, 7]
                        //c = c XOR w[j]
                        //podeliti c na 8 bajta
                        //a = a - (sbox.S0[c0] XOR sbox.s1[c2] XOR sbox.S2[c4] XOR sbox.S3[c6])
                        //b = b + (sbox.S3[c1] XOR sbox.s2[c3] XOR sbox.S1[c5] XOR sbox.S3[c7])
                        //b = b * (i + 1)

                    //if (i == 0)
                        //w[0] do w[7] iz pdf
                        //...
                    //else if (i == 1)
                        //w[0] do w[7] iz pdf
                        //...
                 
                //h0 = h0 + a
                //h1 = h1 + b
                //h2 = h2 + c
        }

        public string Result()
        {
            return h0.ToString() + h1.ToString() + h2.ToString();
        }
    }
}
