using System;
using System.Windows.Forms;
using Bibliothek;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private Game game;
        private User user;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            user = new User("неизвестно");
            var userInfoForm = new UserInfoForm(user);
            var result = userInfoForm.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                Close();
            }
            else
            {
                game = new Game(user);
                ShowNextQuestion();
            }
            textBox.Focus();
        }

        private void ShowNextQuestion()
        {
            var currentQuestion = game.PopRandomQuestion();
            questionTextLabel.Text = currentQuestion.questionText;
            questionNumberLabel.Text = game.GetQuestionNumberInfo();
            textBox.Clear();
            textBox.Focus();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var isValid = User.IsValid(textBox.Text, out var userAnswer, out var errorMessage);
            if (!isValid)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            textBox.Focus();
            game.AcceptAnswer(userAnswer);

            textBox.Clear();
            if (game.End())
            {
                var diagnose = game.CalculateDiagnose();
                MessageBox.Show(diagnose);

                UserResultsStorage.Append(user);
                return;
            }
            ShowNextQuestion();
        }

        private void показатьСтатистикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultsForm = new UserResultsForm();
            resultsForm.ShowDialog(this);
        }
    }
}
