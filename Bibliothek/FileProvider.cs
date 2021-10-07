using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    public class FileProvider
    {
        public static void Append(string path, string value)
        {
            using StreamWriter textToFile = new(path, true, Encoding.Unicode);
            textToFile.WriteLine(value);
            textToFile.Close();
        }

        public static string Get(string path)
        {
            using StreamReader readFromFile = new(path, Encoding.Unicode);
            var textFromFile = readFromFile.ReadToEnd();
            readFromFile.Close();
            return textFromFile;
        }
    }
}
