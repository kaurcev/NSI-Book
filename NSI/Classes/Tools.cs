using Npgsql;
using NSI.Classes.Postgresql;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using static Mono.Security.X509.X520;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NSI.Classes
{
    internal class Tools
    {
        public static string NSIServer = "nsi.rosminzdrav.ru";
        public static string userKey = "2b6a3146-9b41-4d0a-a3b0-51d294cf2e03";
        public static string telegramAPI = "7540493533:AAF6_rPD64rkmIwwQpd2fWP3zqHY-j1zYHA";
        public static string telegramChat = "-1002165970417";
        public static string apitelegram = "api.telegram.org";
        public static string Fetch(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string responseJson = reader.ReadToEnd();
                    return responseJson;
                }
            }
            catch (WebException ex)
            {

                Sv.Log(ex.Message, ex.StackTrace);
                return "";
            }
        }
        public static bool IsDirectoryEmpty(string path)
        {
            return Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0;
        }

        public static string GetNawDate()
        {
            return DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy");
        }

        public static void tgbot(string text)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; 
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
                    string response = client.DownloadString(new Uri($"https://{apitelegram}/bot{telegramAPI}/sendMessage?chat_id={telegramChat}&text={text}"));
                }
                catch (WebException ex)
                {
                    Sv.Log(ex.Message, ex.StackTrace);
                }
            }
        }
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string Fix(string htmlString)
        {
            try
            {
                string textOnly = Regex.Replace(htmlString, "<.*?>", string.Empty);
                string decodedString = HttpUtility.HtmlDecode(textOnly);
                if (decodedString.Trim() != "")
                {
                    return decodedString.Trim();
                }
                return $"Данные отсутствуют.";
            }
            catch(Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                return $"Данные отсутствуют.";
            }
        }
        public static void MessageShow(NotifyIcon notifyIcon, string headmessage, string message, int time)
        {
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = message;
            notifyIcon.BalloonTipTitle = headmessage;
            notifyIcon.ShowBalloonTip(time);
        }

        public static void DeadApp()
        {
            if (Application.OpenForms.Count == 1)
            {
                Application.Exit();
            }
        }


        public static string ToData(string input)
        {
            input = input.Trim('\'');
            string[] formats =
            {
            "dd-MM-yyyy", "dd.MM.yyyy", "dd/MM/yyyy",
            "MM-dd-yyyy", "MM.dd.yyyy", "MM/dd/yyyy",
            "yyyy-MM-dd", "yyyy.MM.dd", "yyyy/MM/dd",
            "dd-MM-yy", "dd.MM.yy", "dd/MM/yy",
            "MM-dd-yy", "MM.dd.yy", "MM/dd/yy",
            "yy-MM-dd", "yy.MM.dd", "yy/MM/dd"
        };

            if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return $"\'{date.ToString("yyyy-MM-dd")}\'";
            }
            else
            {
                return $"\'{input}\'";
            }
        }

        public static void OpenSite()
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://nsi.rosminzdrav.ru/");
            Process.Start(sInfo);
        }
        public static void OpenFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Process.Start(new ProcessStartInfo()
                {
                    FileName = path,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                MessageBox.Show("Не удалось открыть папку: " + ex.Message);
            }
        }
        public static void NotivState(NotifyIcon notifyIcon, string state)
        {
            notifyIcon.Text = state;
        }

        public static void Title(Form form, string title)
        {
            form.Text = $"NSI | {Fix(title)}";
        }

        public static bool ImportToPGSQL(string sqlFilePath)
        {
            try
            {
                string sqlScript = File.ReadAllText(sqlFilePath, Encoding.Default);
                sqlcommand(sqlScript);
                return true;
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                return false;
            }
        }

        public static bool checktable(string tablename)
        {

            DatabaseConfig config = ConfigManager.GetDatabaseConfig();
            string connectionString = $"Host={config.Host};Port={config.Port};Username={config.Username};Password={config.Password};Database={config.Database}";
            string commandcode = $"SELECT EXISTS( SELECT 1 FROM pg_tables WHERE schemaname = '{config.Shema}' AND tablename = '{tablename}' ) AS table_exists;";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(commandcode, connection))
                {
                    bool tableExists = (bool)command.ExecuteScalar();
                    return tableExists;
                }
            }
        }

        public static void sqlcommand(string commandcode)
        {
            DatabaseConfig config = ConfigManager.GetDatabaseConfig();
            string connectionString = $"Host={config.Host};Port={config.Port};Username={config.Username};Password={config.Password};Database={config.Database}";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(commandcode, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
