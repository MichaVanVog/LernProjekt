using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class UserResultsStorage
    {
        public static string File = @"C:\Users\ipbw\source\repos\Lernen\ConsoleApp\formerDiagnosesFile.txt";
        public static void Append(User user)
        {
            var textToFile = user.UserName + "*" + user.Diagnose;
            FileProvider.Append(File, textToFile);
        }

        public static List<User> GetAll()
        {
            var textFromFile = FileProvider.Get(File);
            var textFromTheFile = textFromFile.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List <User> users = new List<User>();
            foreach (var line in textFromTheFile)
            {
                var data = line.Split('*');
                var user = new User(data[0]);
                user.Diagnose = data[1];
                users.Add(user);
            }
            return users;
        }
    }
}
