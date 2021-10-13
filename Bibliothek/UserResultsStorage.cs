using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bibliothek
{
    public class UserResultsStorage
    {
        private static string fileForUserResults = @"C:\Users\ipbw\source\repos\Lernen\formerDiagnosesFile.json";

        public static string FileForUserResults { get => fileForUserResults; set => fileForUserResults = value; }

        public static void Append(User user)
        {
            var userResults = GetAll();
            userResults.Add(user);
            Save(userResults);
        }

        public static List<User> GetAll()
        {
            if(!FileProvider.Exists(FileForUserResults))
            {
                return new List<User>();
            }
            var textFromFile = FileProvider.Get(FileForUserResults);
            var userResults = JsonConvert.DeserializeObject<List<User>>(textFromFile);
            return userResults;
        }

        static void Save(List<User> userResults)
        {
            var jsonData = JsonConvert.SerializeObject(userResults, Formatting.Indented);
            FileProvider.Replace(FileForUserResults, jsonData);
        }
    }
}
