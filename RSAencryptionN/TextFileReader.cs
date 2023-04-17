using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAencryptionN
{
    internal class TextFileReader
    {
        private readonly string filePath;

        public TextFileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public string[] ReadLines()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found at path: {filePath}");
            }

            return File.ReadAllLines(filePath);
        }
    }
}
