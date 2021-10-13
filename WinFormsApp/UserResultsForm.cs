using System;
using Bibliothek;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class UserResultsForm : Form
    {
        public UserResultsForm()
        {
            InitializeComponent();
        }

        private void UserResultsForm_Load(object sender, EventArgs e)
        {
            var results = UserResultsStorage.GetAll();
            foreach (var result in results)
            {
                resultsDataGridView.Rows.Add(result.UserName, result.CalculatedAnswers, result.Diagnose);
            }
        }
    }
}
