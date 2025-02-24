using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class listForm : Form
    {
        // Id użytkownika (powinno być ustawiane z formularza logowania)
        public static int id;

        public listForm()
        {
            InitializeComponent();
        }

        private void listForm_Load(object sender, EventArgs e)
        {
            // Sprawdzamy, czy mamy przypisane id użytkownika
            if (id != 0)
            {
                LoadUserTasks(id);
            }
            else
            {
                MessageBox.Show("Brak przypisanego id użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserTasks(int userId)
        {
            // Połączenie z bazą danych
            string connectionString = "Server=localhost;Database=todolistapp;User=admin;Password=admin;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                // Otwarcie połączenia z bazą danych
                connection.Open();

                // Zapytanie SQL, aby pobrać tytuły zadań użytkownika
                string query = "SELECT title FROM tasks WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userId", userId);

                // Wykonanie zapytania i pobranie wyników
                MySqlDataReader reader = cmd.ExecuteReader();

                // Dodawanie zadań do listBox
                listBoxTasks.Items.Clear(); // Czyszczenie listy przed dodaniem nowych danych

                while (reader.Read())
                {
                    // Dodajemy tytuł zadania do listBox
                    listBoxTasks.Items.Add(reader["title"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Wypisanie błędu w przypadku problemu z połączeniem
                MessageBox.Show($"Błąd podczas ładowania zadań: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Upewnij się, że połączenie zostanie zamknięte
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
