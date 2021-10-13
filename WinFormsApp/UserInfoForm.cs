using System.Windows.Forms;
using Bibliothek;

namespace WinFormsApp
{
    public partial class UserInfoForm : Form
    {
        private User user;
        public UserInfoForm(User user)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Введите свое имя!", "Внимание", MessageBoxButtons.OK);
                return;
            }

            user.UserName = nameTextBox.Text;

            Close();
        }
    }
}
