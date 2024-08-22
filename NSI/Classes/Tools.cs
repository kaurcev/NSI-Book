﻿using Npgsql;
using NSI.Classes.Postgresql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace NSI.Classes
{
    internal class Tools
    {
        public static string NSIServer = "nsi.rosminzdrav.ru";
        public static string userKey = "2b6a3146-9b41-4d0a-a3b0-51d294cf2e03";
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
            catch
            {
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
            if (Application.OpenForms.Count > 1)
            {
                Application.Exit();
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
                Process.Start(new ProcessStartInfo()
                {
                    FileName = path,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception ex)
            {
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

        public static string ImportToPGSQL(string sqlFilePath)
        {
            try
            {
                DatabaseConfig config = ConfigManager.GetDatabaseConfig();
                string connectionString = $"Host={config.Host};Port={config.Port};Username={config.Username};Password={config.Password};Database={config.Database}";

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlScript = File.ReadAllText(sqlFilePath, Encoding.Default);
                    using (var command = new NpgsqlCommand(sqlScript, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                return $"[ Загружен скрипт: {sqlFilePath} ]{Environment.NewLine}";
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                return $"[ Произошла ошибка: {ex.Message} ]{Environment.NewLine}";
            }
        }

    }
}
