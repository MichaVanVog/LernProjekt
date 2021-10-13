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

        public static void Replace(string path, string value)
        {
            var writer = new StreamWriter(path, false, Encoding.Unicode);
            writer.WriteLine(value);
            writer.Close();
        }

        public static string Get(string path)
        {
            using StreamReader readFromFile = new(path, Encoding.Unicode);
            var textFromFile = readFromFile.ReadToEnd();
            readFromFile.Close();
            return textFromFile;
        }

        public static bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
