using System;

namespace Bibliothek
{
    public class User
    {
        public string UserName;
        public int UserAnswer;
        public int CalculatedAnswers;
        public string Diagnose;
        public User(string nameOfCandidate)
        {
            UserName = nameOfCandidate;
            UserAnswer = 0;
            CalculatedAnswers = 0;
            Diagnose = "Неизвестно";
        }
        public void CalcRightAnswers()
        {
            CalculatedAnswers++;
        }

        public static bool IsValid(string answer, out int userAnswer, out string message)
        {
            userAnswer = 0;
            message = "";
            try
            {
                userAnswer = Convert.ToInt32(answer);
                return true;
            }
            catch (FormatException)
            {

                message = "Введите число";
                return false;
            }
            catch (OverflowException)
            {
                message = "Введите число меньшее чем 10^9!";
                return false;
            }
        }
    }
}
