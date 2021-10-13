using System;
using System.Collections.Generic;

namespace Bibliothek
{
    public class Game
    {
        private List<Questions> questions;
        private Questions currentQuestion;
        private int allQuestionsCount;
        private User user;
        private int questionsAmount;

        public Game(User user)
        {
            this.user = user;
            questions = QuestionsStorage.GetQuestions();
            allQuestionsCount = questions.Count;
        }

        public Questions PopRandomQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questions.RemoveAt(randomIndex);
            questionsAmount++;
            return currentQuestion;
        }

        public void AcceptAnswer(int userAnswer)
        {
            var rightAnswer = currentQuestion.answerNumber;

            if (userAnswer == rightAnswer)
            {
                user.CalcRightAnswers();
            }
        }

        public string CalculateDiagnose()
        {
            DiagnoseCalculator.Calculate(user, allQuestionsCount);

            return $"{user.UserName}, Ваш диагноз: {user.Diagnose}";
        }

        public bool End()
        {
            return questions.Count == 0;
        }
        public int GetQuestionsCount()
        {
            return allQuestionsCount;
        }

        public string GetQuestionNumberInfo()
        {
            return "Вопрос №" + questionsAmount;
        }
    }
}
