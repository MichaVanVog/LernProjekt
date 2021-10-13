using System;
using System.Text;
using System.Collections.Generic;
using Bibliothek;

namespace ConsoleApp
{
    class Program
    {

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine("Назовите Ваше имя");
            var user = new User(Console.ReadLine());
            var game = new Game(user);
            var questionsAmount = game.GetQuestionsCount();
            Console.WriteLine($"{user.UserName}, Вам будут заданы {questionsAmount} вопросов:\n");

            while (questionsAmount > 0)
            {
                var currentQuestion = game.PopRandomQuestion();
                Console.Write(game.GetQuestionNumberInfo());
                Console.WriteLine(currentQuestion.questionText);
                var userAnswer = GetUserAnswer(user);
                game.AcceptAnswer(userAnswer);
            }

            Console.WriteLine(game.CalculateDiagnose());
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
                var isValid = User.IsValid(Console.ReadLine(), out var userAnswer, out var errorMessage);
                while (!isValid)
                {
                    Console.WriteLine(errorMessage);
                    isValid = User.IsValid(Console.ReadLine(), out userAnswer, out errorMessage);
                }
                return userAnswer;
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
