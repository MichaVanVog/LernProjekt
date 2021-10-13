using System.Collections.Generic;

namespace Bibliothek
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
    }
}
