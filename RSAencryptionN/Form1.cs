using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using RSAencryptionN;

namespace RSA_Encryption_Decryption
{
    public partial class Form1 : Form
    {
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        //RsaKeySaver RSAE = new RsaKeySaver();
        byte[] plaintext;
        byte[] encryptedtext; 

        public Form1()
        {
            InitializeComponent();          
        }
        //Encrypt Button
        private void EncButton_Click(object sender, EventArgs e)
        {
            
            //CipherText.Text = RSAE.Encrypt(PlainTextInput.Text);
            plaintext = ByteConverter.GetBytes(PlainTextInput.Text);
            encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
            CipherText.Text = ByteConverter.GetString(encryptedtext);

        }
        //Decrypt Button
        private void DecButton_Click(object sender, EventArgs e)
        {
            byte[] decryptedtext = Decryption(encryptedtext, RSA.ExportParameters(true), false);
            PlainTextOutput.Text = ByteConverter.GetString(decryptedtext);
            //PlainTextOutput.Text = RSAE.Decrypt(CipherText.Text);
        }
        //Method for Encryption
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey); encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                } return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        //Method for Decryption
        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save save = new Save("encryptedtext.txt");
            save.SaveToFile(CipherText.Text);
            //RSAE.SaveKey();
        }

        private void CipherText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var reader = new TextFileReader("C:\\Users\\t430\\Source\\Repos\\RSAencryptionN\\RSAencryptionN\\encryptedfile.txt");
            var lines = reader.ReadLines();

            foreach (var line in lines)
            {
                textBox1.Text = line;
            }

            //RSAE.LoadKey();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void PlainTextOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

