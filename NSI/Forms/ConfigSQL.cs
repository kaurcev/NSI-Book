using NSI.Classes.Postgresql;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace NSI.Forms
{
    public partial class ConfigSQL : Form
    {
        public ConfigSQL()
        {
            InitializeComponent();
            LoadCurrentConfig();
        }

        public string CheckPGSQLConnection()
        {
            try
            {
                string host = textBoxHost.Text;
                string username = textBoxUsername.Text;
                string password = textBoxPassword.Text;
                string database = textBoxDatabase.Text;
                string port = port_l.Text;
                string connectionString = $"Host={host};Port={port};Username={username};Password={password};Database={database}";

                using (var connection = new Npgsql.NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        return "Соединение с базой данных установлено успешно.";
                    }
                    else
                    {
                        return "Не удалось установить соединение с базой данных.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"[ Произошла ошибка: {ex.Message} ]{Environment.NewLine}";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string result = CheckPGSQLConnection();
            e.Result = result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label6.Text = e.Result.ToString();
            button1.Enabled = true;
            button2.Enabled = true;
        }

        public void SaveConfig()
        {
            try
            {
                string host = textBoxHost.Text;
                string username = textBoxUsername.Text;
                string password = textBoxPassword.Text;
                string database = textBoxDatabase.Text;
                string port = port_l.Text;
                string shema = shema_l.Text;
                ConfigManager.SetDatabaseConfig(host, username, password, database, port, shema);
                MessageBox.Show("Параметры подключения сохранены.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }


        }

        private void LoadCurrentConfig()
        {
            DatabaseConfig config = ConfigManager.GetDatabaseConfig();
            textBoxHost.Text = config.Host;
            textBoxUsername.Text = config.Username;
            textBoxPassword.Text = config.Password;
            textBoxDatabase.Text = config.Database;
            port_l.Text = config.Port;
            shema_l.Text = config.Shema;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "Попытка соединения...";
            button1.Enabled = false;
            button2.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void ConfigSQL_Load(object sender, EventArgs e)
        {

        }
    }
}
