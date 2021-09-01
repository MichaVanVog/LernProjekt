﻿using System.Collections.Generic;

namespace ConsoleApp
{
    public class Questions
    {
        public string questionText;
        public int answerNumber;

        public Questions(string questions, int answers)
        {
            questionText = questions;
            answerNumber = answers;
        }

        public static List<Questions> GetQuestions()
        {
            var questions = new List<Questions>();
            questions.Add(new Questions("Сколько будет два плюс два умноженное на два?", 6));
            questions.Add(new Questions("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?", 9));
            questions.Add(new Questions("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
            questions.Add(new Questions("Укол делают каждые полчаса, сколько нужно минут для трех уколов?", 60));
            questions.Add(new Questions("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
            return questions;
        }
    }
}