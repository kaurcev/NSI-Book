using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSI.Classes
{
    internal class Sv
    {
        //   private static readonly string BaseDirectory = @"S:\\Отдел разработки и внедрения ПО\\Каурцев А. Е\\serv\\www\\NSI\\logs";
        private static readonly string BaseDirectory = @".//";
        public static readonly string LogDirectory = BaseDirectory;
        public static readonly string ErrorLogFile = BaseDirectory + @"\\errors.log";
        public static void Log(string message, string stackTrace)
        {
            try
            {
                if (!File.Exists(ErrorLogFile))
                {
                    using (StreamWriter sw = new StreamWriter(ErrorLogFile, true, Encoding.Default))
                    {
                        string header = "Время исключения | ПК | ПОЛЬЗОВАТЕЛЬ | ДАННЫЕ | ДЕТАЛИ";
                        sw.WriteLine(header);
                    }
                }

                string shortStackTrace = stackTrace.Length > 50 ? stackTrace.Substring(stackTrace.Length - 50) : stackTrace;

                using (StreamWriter sw = new StreamWriter(ErrorLogFile, true, Encoding.Default))
                {
                    string computerName = Environment.MachineName;
                    string userName = Environment.UserName;
                    string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {computerName} | {userName} | {message.Replace(Environment.NewLine, " ")} | {shortStackTrace.Replace(Environment.NewLine, " ")}";
                    sw.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи в лог: {ex.Message}");
            }
        }
    }
}
