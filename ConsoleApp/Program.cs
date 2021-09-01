using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
            
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var questions = Questions.GetQuestions();

            Console.WriteLine("Назовите Ваше имя");
            var user = new User(Console.ReadLine());
            Console.WriteLine($"{user.UserName}, тест начинается:\n");

            var questionsAmount = questions.Count;

            Random random = new Random();

            while (questions.Count > 0)
            {
                var randomQuestion = random.Next(0, questions.Count);
                Console.WriteLine(questions[randomQuestion].questionText);

                GetUserAnswer(user);

                if (user.UserAnswer == questions[randomQuestion].answerNumber)
                {
                    user.CalcRightAnswers();
                }
                questions.RemoveAt(randomQuestion);
            }

            DiagnoseCalculator.Calculate(user, questionsAmount);

            Console.WriteLine($"{user.UserName}, Ваш диагноз: {user.Diagnose}");
            UserResultsStorage.Append(user);

            Console.WriteLine($"Хотите посмотреть результаты всех предыдущих тестов?");
            Console.WriteLine("Нажмите для просмотра клавишу Y !\nЕсли нет, то клавишу N");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("\n");
                var users = UserResultsStorage.GetAll();
                GetTextFromFile(users);
            }

            static int GetUserAnswer(User user)
            {
                while (int.TryParse(Console.ReadLine(), out user.UserAnswer) == false)
                {
                    Console.WriteLine("Введите число не больше 3 цифр!");
                }
                return user.UserAnswer;
            }

            static void GetTextFromFile(List<User> users)
            {
                Console.WriteLine("{0,-20}{1,-15}", "Имя", "Диагноз");
                foreach (var user in users)
                {
                    Console.WriteLine("{0,-20}{1,-15}", user.UserName, user.Diagnose);
                }
            }
        }
    }
}
