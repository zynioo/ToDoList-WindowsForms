using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class FormMainSign : Form
    {
        public FormMainSign()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm lf = new LoginForm();
            lf.ShowDialog();

            this.Show();
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm rf = new RegisterForm();
            rf.ShowDialog();
            this.Show();
        }
    }
}
