using System;
using System.Windows.Forms;
using Bibliothek;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private Game game;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var user = new User("неизвестно");
            game = new Game(user);
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var currentQuestion = game.PopRandomQuestion();
            questionTextLabel.Text = currentQuestion.questionText;
            questionNumberLabel.Text = game.GetQuestionNumberInfo();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            textBox.Focus();
            var answer = Convert.ToInt32(textBox.Text);
            game.AcceptAnswer(answer);

            textBox.Clear();
            if (game.End())
            {
                var diagnose = game.CalculateDiagnose();
                MessageBox.Show(diagnose);
                return;
            }
            ShowNextQuestion();
        }
    }
}
