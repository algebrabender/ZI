using System.Collections.Generic;

namespace ZIZad
{
    internal interface ICryptoAlgorithm
    {
        List<string> Encrypt(string filePath);
        List<string> Decrypt(string filePath, out bool sameHashes);

        void GenerateAndSaveKey(string fileName);
        void LoadKey(string fileName);
    }
}
