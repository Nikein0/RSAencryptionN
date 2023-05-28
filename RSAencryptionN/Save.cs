using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Encryption_Decryption
{
    internal class Save
    {
        private static string Filename;
        private string path = "C:\\Users\\t430\\Source\\Repos\\RSAencryptionN\\RSAencryptionN\\encryptedfile.txt";
        bool Mode = true;


        public Save(string filename)
        {
            Filename = filename;
        }
        public void SaveToFile(string encryptedText)
        {
            if (Mode == true) {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(encryptedText);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\Niko\\source\\repos\\RSAencryptionN\\RSAencryptionN\\encryptedfile.txt"))
                {
                    writer.WriteLine(encryptedText);
                }
            }
        }
       
        
    }
    
}
