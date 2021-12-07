using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIZad
{
    internal interface ICryptoAlgorithm
    {
        List<string> Encrypt(string filePath);
        List<string> Decrypt(string filePath);

        void GenerateAndSaveKey(string fileName);
        void LoadKey(string fileName);
    }
}
