using System;
using System.Collections.Generic;

namespace Bibliothek
{
    public class UserResultsStorage
    {
        private static string file = @"C:\Users\ipbw\source\repos\Lernen\ConsoleApp\formerDiagnosesFile.txt";

        public static string File { get => file; set => file = value; }

        public static void Append(User user)
        {
            var textToFile = user.UserName + "*" + user.Diagnose;
            FileProvider.Append(File, textToFile);
        }

        public static List<User> GetAll()
        {
            var textFromFile = FileProvider.Get(File);
            var textFromTheFile = textFromFile.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<User> users = new();
            foreach (var line in textFromTheFile)
            {
                var data = line.Split('*');
                var user = new User(data[0])
                {
                    Diagnose = data[1]
                };
                users.Add(user);
            }
            return users;
        }
    }
}
