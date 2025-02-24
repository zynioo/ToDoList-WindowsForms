using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxNickname.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                labelStatus.Text = "Wszystkie pola muszą być wypełnione!";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
            string connectionString = "Server=localhost;Database=todolistapp;User=admin;Password=admin;";
            Login(username, password, connectionString);
        }

        private void Login(string username, string password, string connectionString)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Połączenie z bazą danych zostało nawiązane!");
                string query = "SELECT id FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    labelStatus.Text = "Zalogowano!";
                    labelStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelStatus.Text = "Nie zalogowano!";
                    labelStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas łączenia się z bazą danych: {ex.Message}");
                labelStatus.Text = "Błąd połączenia!";
                labelStatus.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Połączenie zostało zamknięte.");
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            labelStatus.Text = "";
        }

        private void labelBackToMainLogForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
