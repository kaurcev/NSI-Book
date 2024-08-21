using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NSI
{
    public partial class ExportView : Form
    {
        public static string oid = "1.2.643.5.1.13.13.99.2.228";
        public static string version = "3.5";
        public static string total = "1317";

        private ManualResetEvent pauseEvent = new ManualResetEvent(true);
        private bool isPaused = false;

        public static double stepint = 500;
        private double step = 0;

        private List<string> failedFiles = new List<string>();

        public ExportView()
        {
            InitializeComponent();
        }

        private void ExportView_Load(object sender, EventArgs e)
        {
            oid_l.Text = oid;
            version_l.Text = version;
            label23.Text = total;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            buttonPauseResume.Enabled = true;
            dataLoader.RunWorkerAsync();
        }

        private void dataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            string baseFolderPath = $@".//temp//{oid_l.Text}//";
            if (Directory.Exists(baseFolderPath))
            {
                Directory.Delete(baseFolderPath, true);
            }
            Directory.CreateDirectory(baseFolderPath);

            step = (int)Math.Ceiling(Convert.ToDouble(label23.Text) / Convert.ToDouble(numericUpDown1.Value));
            List<int> failedPages = new List<int>();

            for (int i = 1; i <= step; i++)
            {
                pauseEvent.WaitOne();
                if (!LoadDataFromUrl(i, failedPages))
                {
                    failedPages.Add(i);
                }
            }

            recov.Visible = true;
            recov.Text = "Проверка целостности";
            foreach (int page in failedPages)
            {
                pauseEvent.WaitOne();
                if (!Directory.Exists(baseFolderPath))
                {
                    Directory.CreateDirectory(baseFolderPath);
                }
                recov.Text = $"Докачка и восстановление тома №{page}";
                LoadDataFromUrl(page, null);
            }
            recov.Text = "Восстановление завершено";
        }

        private bool LoadDataFromUrl(int page, List<int> failedPages)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    statis.Text = $"Загрузка {page} / {step} тома. \nВ томе до {numericUpDown1.Value} значений. \nВсего: {label23.Text} значений";
                });

                string filePath = $@".//temp//{oid_l.Text}//data_{page}.json";
                string url = $"http://{Tools.NSIServer}/port/rest/data?userKey={Tools.userKey}&identifier={oid_l.Text}&version={version_l.Text}&page={page}&size={numericUpDown1.Value}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            long totalBytes = response.ContentLength;
                            long totalReadBytes = 0;
                            while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                pauseEvent.WaitOne();
                                fileStream.Write(buffer, 0, bytesRead);
                                totalReadBytes += bytesRead;

                                this.Invoke((MethodInvoker)delegate
                                {
                                    progressBar1.Value = Convert.ToInt32((page * 100) / step);
                                    if (totalBytes > 0)
                                    {
                                        progressBar2.Value = (int)((totalReadBytes * 100) / totalBytes);
                                    }
                                });
                            }
                        }
                        return true;
                    }
                    else
                    {
                        HandleError("Ошибка запроса: " + response.StatusCode);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                HandleError("Ошибка запроса: " + ex.Message);
                return false;
            }
        }

        private void HandleError(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Tools.MessageShow(notify, "Ошибка", message, 5);
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Реализация не предоставлена
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                pauseEvent.Set();
                buttonPauseResume.Text = "ПАУЗА";
            }
            else
            {
                pauseEvent.Reset();
                buttonPauseResume.Text = "ПРОДОЛЖИТЬ";
            }
            isPaused = !isPaused;
        }

        private void dataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            numericUpDown1.Enabled = true;
            // buttonPauseResume.Enabled = false;
            convertToCSV.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            convertToCSV.RunWorkerAsync();
        }
        public string exporturl = "";
        private void convertToCSV_DoWork(object sender, DoWorkEventArgs e)
        {
            recov.Visible = false;
            try
            {
                dataLoader.CancelAsync();
                string exportPath = Path.Combine(".//data", oid_l.Text);
                CreateDirectoryIfNotExists(exportPath);
                string versionFolderPath = Path.Combine(exportPath, version_l.Text);
                exporturl = versionFolderPath;
                CreateDirectoryIfNotExists(versionFolderPath);

                List<int> failedIndexes = new List<int>();
                foreach (int index in Enumerable.Range(1, Convert.ToInt32(step)))
                {
                    pauseEvent.WaitOne();
                    if (!ExportJsonToCsv(index, versionFolderPath))
                    {
                        failedIndexes.Add(index);
                    }
                }
                recov.Visible = true;
                recov.Text = "Проверка целостнности";
                RetryFailedFiles(failedIndexes, versionFolderPath);

                // Tools.NotivState(notify, "Экспорт завершён");
                // Tools.MessageShow(notify, "Успешно", "Экспорт завершён", 5);
                ToggleExportButtons(true);
            }
            catch (Exception ex)
            {
                HandleExportError(ex);
            }
        }

        private bool ExportJsonToCsv(int index, string versionFolderPath)
        {
           // Tools.NotivState(notify, $"Экспорт: {index} из {step}");
            string jsonFilePathtemp = Path.Combine(".//temp", oid_l.Text);
            string jsonFilePath = Path.Combine(jsonFilePathtemp, $"data_{index}.json");
            string csvFilePath = Path.Combine(versionFolderPath, $"data_{index}.csv");
            progressBar2.Value = Convert.ToInt32((index * 100) / step);
            if (!FileExists(jsonFilePath, index))
            {
                return false;
            }

            if (TryExportJsonToCsv(jsonFilePath, csvFilePath))
            {
                File.Delete(jsonFilePath);
                return true;
            }
            else
            {
              //  Tools.MessageShow(notify, "Ошибка", "Не удалось экспортировать данные", 5);
                return false;
            }
        }

        private bool FileExists(string filePath, int index)
        {
            if (!File.Exists(filePath))
            {
               // Tools.MessageShow(notify, "Ошибка", $"Том {index} отсутствует, экспорт невозможен", 5);
                return false;
            }
            return true;
        }

        private void RetryFailedFiles(List<int> failedIndexes, string versionFolderPath)
        {
            foreach (int index in failedIndexes)
            {
                pauseEvent.WaitOne();
                // Tools.NotivState(notify, $"Повторная попытка экспорта: {index} из {step}");
                recov.Text = $"Повторная попытка экспорта: №{index}";
                ExportJsonToCsv(index, versionFolderPath);
            }
              recov.Text = "Восстаноление завершено";
        }

        private bool TryExportJsonToCsv(string jsonFilePath, string csvFilePath)
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath, Encoding.UTF8);
                var list = JObject.Parse(json)["list"].ToObject<List<List<ColumnValue>>>();
                var headers = GetDistinctHeaders(list);
                var csvContent = new StringBuilder();

                csvContent.AppendLine(string.Join("|", headers));

                foreach (var row in list)
                {
                    pauseEvent.WaitOne();
                    var values = headers.Select(header =>
                        row.FirstOrDefault(item => item.column == header)?.value != null
                            ? $"\"{row.First(item => item.column == header).value}\""
                            : "").ToArray();
                    csvContent.AppendLine(string.Join("|", values));
                }

                File.WriteAllText(csvFilePath, csvContent.ToString(), Encoding.Default);
                return true;
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                return false;
            }
        }

        private string[] GetDistinctHeaders(List<List<ColumnValue>> list)
        {
            return list.SelectMany(row => row.Select(item => item.column)).Distinct().ToArray();
        }
        private void HandleExportError(Exception ex)
        {
            Sv.Log(ex.Message, ex.StackTrace);
            // Tools.MessageShow(notify, "Ошибка", "Произошла ошибка: " + ex.Message, 5);
        }

        private void ToggleExportButtons(bool isEnabled)
        {
            button2.Enabled = isEnabled;
            button1.Enabled = true;
            numericUpDown1.Enabled = true;
            buttonPauseResume.Enabled = !isEnabled;
        }

        private void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public class ColumnValue
        {
            public string column { get; set; }
            public string value { get; set; }
        }

        private void convertToCSV_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataLoader.CancelAsync();
            convertToCSV.CancelAsync();
        }
    }
}