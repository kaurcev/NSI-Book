using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace NSI
{
    public partial class ExportView : Form
    {
        public static string oid = "1.2.643.5.1.13.13.99.2.228";
        public static string version = "3.5";
        public static string total = "1317";
        public static string key = "id";

        public static string destinationBasePath = @".\dump_sql\";

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
            label1.Text = "Загрузка данных";
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
            label1.Text = "Загрузка данных завершена";
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
            dataLoader.CancelAsync();
            label1.Text = "Конвертация данных в CSV";
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            recov.Visible = false;
            try
            {
                string exportPath = Path.Combine(".//data", oid_l.Text);
                if (Directory.Exists(exportPath))
                {
                    Directory.Delete(exportPath, true);
                }
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
            label1.Text = "Конвертация данных в CSV завершена";
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            dataLoader.CancelAsync();
            convertToSQL.RunWorkerAsync();
        }

        private void convertToSQL_DoWork(object sender, DoWorkEventArgs e)
        {
            convertToCSV.CancelAsync();
            label1.Text = "Конвертация данных в SQL";
            try
            {
                // Tools.MessageShow(notify, "Загрузка", "Запущен экспорт в SQL", 5);
                string sourcePath = $@".\data\{oid_l.Text}\{version_l.Text}";
                string destinationPath = $@".\dump_sql\{oid_l.Text}\{version_l.Text}\";
                string fixedText2 = textBox1.Text;
                if (Directory.Exists(destinationPath))
                {
                    Directory.Delete(destinationPath, true);
                }

                ExportSql(sourcePath, destinationPath, oid_l.Text, fixedText2);
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }
        public void ExportSql(string folderPath, string outputFolderPath, string tableName, string schemaName)
        {
            CreateDirectoryIfNotExists(folderPath);
            CreateDirectoryIfNotExists(outputFolderPath);

            string[] csvFiles = Directory.GetFiles(folderPath, "*.csv");
            List<string> failedFiles = new List<string>();

            try
            {
                int io = 1;
                foreach (string csvFilePath in csvFiles)
                {
                    pauseEvent.WaitOne();

                    try
                    {
                        ProcessCsvFile(csvFilePath, outputFolderPath, tableName, schemaName);
                        UpdateProgress(io++, csvFiles.Length);
                    }
                    catch (Exception  ex)
                    {
                        failedFiles.Add(csvFilePath);
                       // Tools.MessageShow(notify, "Ошибка", $"Ошибка при обработке файла: {csvFilePath} - {ex.Message}", 5);
                    }
                }

                RetryFailedFiles(failedFiles, outputFolderPath, tableName, schemaName);
            }
            catch (Exception ex)
            {
              //  Tools.MessageShow(notify, "Ошибка!", "Ошибка при загрузке папок: " + ex.Message, 5);
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }
        private void RetryFailedFiles(List<string> failedFiles, string outputFolderPath, string tableName, string schemaName)
        {
            foreach (string failedFile in failedFiles)
            {
                pauseEvent.WaitOne();
                try
                {
                    ProcessCsvFile(failedFile, outputFolderPath, tableName, schemaName);
                  //  Tools.NotivState(notify, $"Повторная подготовка скриптов для: {failedFile}");
                }
                catch (Exception ex)
                {
                  //  Tools.MessageShow(notify, "Ошибка", $"Ошибка при повторной обработке файла: {failedFile} - {ex.Message}", 5);
                }
            }
        }
        private void ProcessCsvFile(string csvFilePath, string outputFolderPath, string tableName, string schemaName)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(csvFilePath);
            string sqlFilePath = Path.Combine(outputFolderPath, fileNameWithoutExtension + ".sql");

            using (StreamWriter sw = new StreamWriter(sqlFilePath, false, Encoding.Default))
            using (StreamReader sr = new StreamReader(csvFilePath, Encoding.Default))
            {
                string headerLine = sr.ReadLine();
                if (headerLine == null)
                {
                    MessageBox.Show("CSV файл " + csvFilePath + " пуст.");
                    return;
                }

                string[] columns = ProcessHeaderLine(headerLine);

                while (!sr.EndOfStream)
                {
                    pauseEvent.WaitOne();

                    string line = sr.ReadLine();
                    string[] values = ProcessDataLine(line);
                    string insertStatement = GenerateInsertStatement(tableName, columns, values, schemaName);
                    sw.WriteLine(insertStatement);
                }
            }
        }
        private string[] ProcessHeaderLine(string headerLine)
        {
            return headerLine.Split('|').Select(column => string.IsNullOrEmpty(column) ? "NULL" : "\"" + column.Replace("\"", "") + "\"").ToArray();
        }
        public string GenerateInsertStatement(string tableName, string[] columns, string[] values, string schemaName)
        {
            string columnsPart = string.Join(", ", columns);
            string valuesPart = string.Join(", ", values);
            return $"INSERT INTO \"{schemaName}\".\"{tableName}\" ({columnsPart}) VALUES ({valuesPart}) ON CONFLICT ({columns[0]}) DO NOTHING;";
        }

        private string[] ProcessDataLine(string line)
        {
            return line.Split('|').Select(value => string.IsNullOrEmpty(value) ? "NULL" : "'" + value.Replace("\"", "") + "'").ToArray();
        }
        private void UpdateProgress(int current, int total)
        {
          //  Tools.NotivState(notify, $"Подготовка скриптов: {current} из {total}");
            int percentComplete = (int)((current * 100) / total);
         //    label22.Text = $"Подготовка скриптов: {current} из {total}";
            progressBar1.Value = percentComplete;
        }

        private void convertToSQL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            convertToSQL.CancelAsync();
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            label1.Text = "Конвертация данных в SQL завершена. Можете загрузить данные";
            button1.Enabled = true;
            numericUpDown1.Enabled = true;
            buttonPauseResume.Enabled = false;
        }
    }
}