using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    public class QuestionsStorage
    {
        private static string fileForQuestions = @"C:\Users\ipbw\source\repos\Lernen\questionsFile.json";
        public static string FileForQuestions { get => fileForQuestions; set => fileForQuestions = value; }

        public static void Add (Questions newQuestion)
        {
            var questionsFromFile = GetQuestions();
            questionsFromFile.Add(newQuestion);
            Save(questionsFromFile);
            
        }
        public static List<Questions> GetQuestions()
        {
            var questions = new List<Questions>();
            if (!FileProvider.Exists(FileForQuestions))
            {
                questions.Add(new Questions("Сколько будет два плюс два умноженное на два?", 6));
                questions.Add(new Questions("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?", 9));
                questions.Add(new Questions("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Questions("Укол делают каждые полчаса, сколько нужно минут для трех уколов?", 60));
                questions.Add(new Questions("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));

                Save(questions);
            }
            else
            {
                var textFromFile = FileProvider.Get(FileForQuestions);
                questions = JsonConvert.DeserializeObject<List<Questions>>(textFromFile);
            }
            return questions;
        }
        static void Save(List<Questions> questions)
        {
            var jsonData = JsonConvert.SerializeObject(questions, Formatting.Indented);
            FileProvider.Replace(FileForQuestions, jsonData);
        }
    }
}
