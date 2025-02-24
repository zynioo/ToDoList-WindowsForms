using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Pobieramy dane z formularza
            string nickname = textBoxNickname.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string rePassword = textBoxRePassword.Text;

            // Sprawdzamy, czy hasła są takie same
            if (password != rePassword)
            {
                labelStatus.Text = "Hasła nie są takie same!";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Sprawdzamy, czy pola nie są puste
            if (string.IsNullOrWhiteSpace(nickname) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                labelStatus.Text = "Wszystkie pola muszą być wypełnione!";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Walidacja poprawności e-maila
            if (!IsValidEmail(email))
            {
                labelStatus.Text = "Niepoprawny adres e-mail!";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Walidacja hasła
            if (!IsValidPassword(password))
            {
                labelStatus.Text = "Hasło musi zawierać co najmniej 8 znaków, w tym jedną dużą literę, jedną małą literę oraz cyfrę!";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Sprawdzamy unikalność nazwy użytkownika i emaila
            string connectionString = "Server=localhost;Database=todolistapp;User=admin;Password=admin;";
            try
            {
                if (IsUsernameOrEmailTaken(nickname, email, connectionString))
                {
                    labelStatus.Text = "Nazwa użytkownika lub email już istnieje!";
                    labelStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Dodajemy użytkownika do bazy danych
                RegisterUser(nickname, email, password, connectionString);
            }
            catch (Exception ex)
            {
                labelStatus.Text = $"Błąd: {ex.Message}";
                labelStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email; // Jeśli jest poprawny, zwróci prawdziwe
            }
            catch
            {
                return false; // Zwraca fałsz jeśli jest niepoprawny
            }
        }

        private bool IsValidPassword(string password)
        {
            // Wzór regularny dla hasła:
            // 1. Co najmniej 8 znaków
            // 2. Co najmniej jedna wielka litera
            // 3. Co najmniej jedna mała litera
            // 4. Co najmniej jedna cyfra
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$";

            return Regex.IsMatch(password, pattern);
        }

        private bool IsUsernameOrEmailTaken(string nickname, string email, string connectionString)
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                // Sprawdzamy, czy nazwa użytkownika już istnieje
                string query = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", nickname);
                cmd.Parameters.AddWithValue("@email", email);

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                return result > 0; // Jeśli wynik jest większy niż 0, to nazwa lub email są już zajęte
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd połączenia z bazą danych: " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void RegisterUser(string nickname, string email, string password, string connectionString)
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                // Zapytanie INSERT do dodania nowego użytkownika
                string query = "INSERT INTO users (username, email, password, created_at) VALUES (@username, @email, @password, current_timestamp())";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", nickname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password); // Pamiętaj, żeby hasło było haszowane w prawdziwej aplikacji!

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    labelStatus.Text = "Rejestracja zakończona sukcesem!";
                    labelStatus.ForeColor = System.Drawing.Color.Green;

                    // Można zamknąć formularz rejestracji po pomyślnej rejestracji
                }
                else
                {
                    labelStatus.Text = "Wystąpił błąd podczas rejestracji!";
                    labelStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd połączenia z bazą danych: " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void labelBackToMainLogForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
