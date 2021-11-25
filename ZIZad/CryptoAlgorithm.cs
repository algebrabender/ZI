using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIZad
{
    internal interface CryptoAlgorithm
    {
        List<string> Encrypt(string filePath);
        List<string> Decrypt(string filePath);

        //TODO: POTENCIJALNO PREBACITI STEPS I GENERATE/LOAD
    }
}
