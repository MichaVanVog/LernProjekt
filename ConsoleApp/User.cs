namespace ConsoleApp
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
    }
}
