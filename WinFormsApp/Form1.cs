using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibliothek;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private List<Questions> questions;
        private Questions currentQuestion;
        private User user;
        private int countQuestions;
        private int questionsAmount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            user = new User("неизвестно");
            questions = Questions.GetQuestions();
            questionsAmount = questions.Count;
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            countQuestions++;
            Random random = new();
            var randomQuestion = random.Next(0, questions.Count);
            currentQuestion = questions[randomQuestion];
            questionTextLabel.Text = currentQuestion.questionText;
            questionNumberLabel.Text = $"Вопрос № {countQuestions}";
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            textBox.Focus();
            var answer = Convert.ToInt32(textBox.Text);
            if (answer == currentQuestion.answerNumber)
            {
                user.CalcRightAnswers();
            }
            questions.Remove(currentQuestion);
            textBox.Clear();
            if (questions.Count==0)
            {
                DiagnoseCalculator.Calculate(user, questionsAmount);
                MessageBox.Show(user.Diagnose, "Ваш Диагноз", MessageBoxButtons.OK);
                return;
            }
            ShowNextQuestion();
        }
    }
}
