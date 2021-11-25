using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIZad
{
    internal class Knapsack : CryptoAlgorithm
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
            P = new int[16]; //koristice se polureci posto je char 16b
            J = new int[16];
        }

        #region Methodes

        private void GenerateKeys()
        {
            //TODO: GENERISATI SUPERRASTUCI NIZ P
            //TODO: NACI n I m
            //TODO: IZRACUNATI J
            //TODO: NACI im
        }

        private void StepOneEncrypt(char wordForCrypting) //CHAR in 16b?
        {
            //TODO: PREVESTI IZ DEKATNOG SISTEMA U BINARI
            //TODO: DOPUNITI DO 16 NULAMA SA DESNE STRANE AKO TREBA
            //TODO: NAPRAVITI NIZ KOJI CE BITI RETURN VREDNOST
        }

        private void StepTwoEncrypt() //TODO: ULAZNI PARAMETAR JE NIZ KOJI JE RETURN IZ STEP ONE
        {
            //TODO: IZRACUNATI C
        }

        private void StepOneDecrypt()
        {
            //TODO: IZRACUNATI TC
            //TODO: PREDSTAVITI TC KAO NIZ ELEMENATA IZ SKUPA P
            //TODO: DOBIJENE FAKTORE PREDSTAVITI KAO BINARNI BROJ
            //TODO: PREVESTI U DEKADNI BROJ
        }

        public List<string> Encrypt(string filePath)
        {
            throw new NotImplementedException();
        }

        public List<string> Decrypt(string filePath)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
