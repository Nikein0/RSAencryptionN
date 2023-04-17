using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSAencryptionN
{
    internal class RsaKeySaver
    {
        private const string KeyFileName = "rsa_key.txt";
        private readonly string _keyFilePath;
        private readonly RSACryptoServiceProvider _rsaProvider;
        public RsaKeySaver()
        {
            _keyFilePath = "C:\\Users\\Niko\\source\\repos\\RSAencryptionN\\RSAencryptionN\\rsa_key.txt"; 
            //Path.Combine(Environment.CurrentDirectory, KeyFileName);
            _rsaProvider = new RSACryptoServiceProvider(2048);
        }
        public void SaveKey()
        {
            var publicKey = _rsaProvider.ToXmlString(false);
            var privateKey = _rsaProvider.ToXmlString(true);
            File.WriteAllText(_keyFilePath, $"{publicKey}:{privateKey}");
        }
        public void LoadKey()
        {
            if (!File.Exists(_keyFilePath))
            {
                throw new FileNotFoundException($"RSA key file not found at {_keyFilePath}");
            }

            var keyData = File.ReadAllText(_keyFilePath);
            var keyParts = keyData.Split(':');
            if (keyParts.Length != 2)
            {
                throw new InvalidDataException("Invalid RSA key data format.");
            }

            _rsaProvider.FromXmlString($"{keyParts[0]}:{keyParts[1]}");
        }
        public string Encrypt(string data)
        {
            var dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            var encryptedBytes = _rsaProvider.Encrypt(dataBytes, true);
            return Convert.ToBase64String(encryptedBytes);
        }
        public string Decrypt(string encryptedData)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedData);
            var decryptedBytes = _rsaProvider.Decrypt(encryptedBytes, true);
            return System.Text.Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
