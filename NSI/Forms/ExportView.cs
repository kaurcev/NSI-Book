using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSI.Classes;
using NSI.Classes.Postgresql;
using NSI.Forms;
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
        public static string oid { get; set; }
        public static string version { get; set; }
        public static string total { get; set; }
        private static string datestart = "";
        private static string datenowend = "";
        private static string DemoJson;
        private static bool Jops = false;
        private static bool cconvert = true;
        private static bool goodJop = true;
        private static bool isPaused = false;
        private static double step = 0;
        private static Responce_v resp_version;
        private static Responce responsed;
        private DatabaseConfig config = ConfigManager.GetDatabaseConfig();
        private ManualResetEvent pauseEvent = new ManualResetEvent(true);
        public ExportView()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(ExportView_KeyDown);
        }

        #region Форма
        private void ExportView_Load(object sender, EventArgs e)
        {
            oid_l.Text = oid;
            version_l.Text = version;
            shema_l.Text = config.Shema;
            versionLoader.RunWorkerAsync();
        }
        private void ExportView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Jops) return;
            var result = MessageBox.Show(
                "У вас выполняется загрузка данных с НСИ. Прервать? \n(Вариант \"Нет\" оставит экспорт в фоне)",
                "Минутку!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Tools.DeadApp();
            }
            else
            {
                e.Cancel = true;
                Hide();
            }
        }
        private void ExportView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                CreateTableView view = new CreateTableView();
                CreateTableView.OID = oid_l.Text;
                CreateTableView.NOTE = structureNotes.Text;
                CreateTableView.VERSION = version_l.Text;
                view.Show();
            }
        }
        private void ExportView_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }
        #endregion Форма

        #region Кнопки
        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void closeJop_Click(object sender, EventArgs e)
        {
            Jops = false;
            goodJop = false;
            closeJop.Enabled = false;
            string exportPathtemp = Path.Combine(@".\data\", oid_l.Text);
            string exportPath = Path.Combine(exportPathtemp, version_l.Text);
            StatusText("Операция была отменена");
            ExportView view = new ExportView();
            ExportView.oid = oid;
            ExportView.version = version;
            view.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                pauseEvent.Set();
                buttonPauseResume.Text = ";";
            }
            else
            {
                pauseEvent.Reset();
                buttonPauseResume.Text = "4";
            }
            isPaused = !isPaused;
        }
        #endregion Кнопки

        #region Вспомогательное
        private bool FileExists(string filePath, int index)
        {
            if (!File.Exists(filePath))
            {
                Tools.MessageShow(notify, "Ошибка", $"Том {index} отсутствует, экспорт невозможен", 5);
                return false;
            }
            return true;
        }
        private void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        #endregion Вспомогательное

        #region Загрузчик версий
        private void versionLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string url = GetVersionUrl();
                resp_version = JsonConvert.DeserializeObject<Responce_v>(Tools.Fetch(url));
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                e.Result = ex;
            }
        }
        private string GetVersionUrl()
        {
            return $"http://{Tools.NSIServer}/port/rest/versions?userKey={Tools.userKey}&identifier={oid_l.Text}&page=1";
        }
        private void versionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            version = versionBox.SelectedItem?.ToString();
            version_l.Text = version;
            if (!string.IsNullOrEmpty(version))
            {
                try
                {
                    infoDataLoader.RunWorkerAsync();
                    demoLoader.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    Tools.MessageShow(notify, "Ошибка", "Ошибка при запуске загрузчиков: " + ex.Message, 5);
                }
            }
        }
        private void versionLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Tools.MessageShow(notify, "Ошибка", "Ошибка при загрузке версий: " + e.Error.Message, 5);
                return;
            }

            versionBox.Items.Clear();

            foreach (var item in resp_version.List)
            {
                versionBox.Items.Add(item.version);
            }

            if (versionBox.Items.Count > 0)
            {
                versionBox.SelectedIndex = 0;
            }
        }

        public class Responce_v
        {
            public string Result { get; set; }
            public object ResultText { get; set; }
            public object ResultCode { get; set; }
            public List<Versions> List { get; set; }
        }
        public class Versions
        {
            public string version { get; set; }
            public object createDate { get; set; }
            public object publishDate { get; set; }
            public object releaseNotes { get; set; }
            public bool archive { get; set; }
        }


        #endregion Загрузчик версий

        #region Загрузчик информации
        private void infoDataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                StatusText("Готов к работе");
                Tools.MessageShow(notify, "Ошибка", "Ошибка при загрузке данных: " + e.Error.Message, 5);
                return;
            }

            if (responsed != null)
            {
                Tools.Title(this, String.Format("{0} v{1}", responsed.fullName, version_l.Text));
                label23.Text = $"{responsed.rowsCount}";
                oid_l.Text = Tools.Fix(responsed.oid);
                fullName.Text = Tools.Fix(responsed.fullName);
                createDate.Text = Tools.Fix($"Создан: {responsed.createDate}");
                lastUpdate.Text = Tools.Fix($"Обновлён: {responsed.lastUpdate}");
                publishDate.Text = Tools.Fix($"Опубликован: {responsed.publishDate}");
                description.Text = Tools.Fix(responsed.description);
                structureNotes.Text = Tools.Fix(responsed.structureNotes);
                releaseNotes.Text = Tools.Fix(responsed.releaseNotes);
                archivePanel.Visible = responsed.archive;
            }
        }
        private string GetDataUrl(string oid, string version)
        {
            return $"http://{Tools.NSIServer}/port/rest/passport?userKey={Tools.userKey}&identifier={oid}&version={version}";
        }

        private void infoDataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string url = GetDataUrl(oid_l.Text, version_l.Text);
                responsed = JsonConvert.DeserializeObject<Responce>(Tools.Fetch(url));
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                e.Result = ex;
            }
        }

        public class Responce
        {
            public string Result { get; set; }
            public object ResultText { get; set; }
            public object ResultCode { get; set; }
            public string fullName { get; set; }
            public string oid { get; set; }
            public string version { get; set; }
            public string createDate { get; set; }
            public string publishDate { get; set; }
            public string lastUpdate { get; set; }
            public string description { get; set; }
            public string structureNotes { get; set; }
            public string releaseNotes { get; set; }
            public bool archive { get; set; }
            public int rowsCount { get; set; }
        }

        #endregion Загрузчик информации

        #region ДемоОбзор
        private void demoLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string url = GetDemoDataUrl(oid_l.Text, version_l.Text);
                DemoJson = Tools.Fetch(url);
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                e.Result = ex;
            }
        }
        private string GetDemoDataUrl(string oid, string version)
        {
            return $"http://{Tools.NSIServer}/port/rest/data?userKey={Tools.userKey}&identifier={oid}&version={version}&page=1&size=10";
        }

        private void demoLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                Tools.MessageShow(notify, "Ошибка", "Ошибка при загрузке демонстрационных данных: " + e.Error.Message, 5);
                return;
            }

            if (DemoJson != null)
            {
                DataGridViewFiller.FillDataGridView(dataGridView1, DemoJson);
            }
        }
        #endregion ДемоОбзор

        #region Проверка перед загрузкой
        public static DateTime startJop;
        private void button1_Click(object sender, EventArgs e)
        {
            startJop = DateTime.Now;
            datestart = Tools.GetNawDate().ToString("HH:mm:ss dd-MM-yyyy");
            goodJop = true;
            cconvert = true;
            if (!Tools.checktable(oid_l.Text))
            {
                HandleTableCreation();
            }
            else
            {
                PrepareForWork();
            }
        }
        private void HandleTableCreation()
        {
            DialogResult result = MessageBox.Show("Перед экспортом нужно создать таблицу. У Вас она не создана. Создаём?",
                                  "Проверка",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CreateTableView view = new CreateTableView();
                CreateTableView.OID = oid_l.Text;
                CreateTableView.NOTE = structureNotes.Text;
                CreateTableView.VERSION = version_l.Text;
                view.Show();
            }
            else
            {
                MessageBox.Show("Перед запуском создайте таблицу, нажав на F5");
            }
        }
        private void PrepareForWork()
        {
            closeJop.Enabled = true;
            config = ConfigManager.GetDatabaseConfig();
            shema_l.Text = config.Shema;
            if (config.Shema != null)
            {
                StatusText("Подготовка к работе...");
                SetControlsState(false);
                buttonPauseResume.Enabled = true;
                dataLoader.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Укажите схему в настройках конфигурации!");
            }
        }
        private void SetControlsState(bool isEnabled)
        {
            versionBox.Enabled = isEnabled;
            startButton.Enabled = isEnabled;
            numericUpDown1.Enabled = isEnabled;
        }
        #endregion Проверка перед загрузкой

        #region Загрузчик
        private void dataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Jops = true;
                StatusText("Проверка наличия скачанных данных ранее");
                step = (int)Math.Ceiling(Convert.ToDouble(label23.Text) / Convert.ToDouble(numericUpDown1.Value));
                string exportPath = Path.Combine(".//data", oid_l.Text);
                string versionFolderPath = Path.Combine(exportPath, version_l.Text);
                Directory.CreateDirectory(versionFolderPath);
                int fileCount = Directory.GetFiles(versionFolderPath).Length;
                if (Tools.IsDirectoryEmpty(versionFolderPath) && step != fileCount)
                {
                    StatusText("Загрузка данных");
                    string baseFolderPath = $@".//temp//{oid_l.Text}//";
                    if (Directory.Exists(baseFolderPath))
                    {
                        Directory.Delete(baseFolderPath, true);
                    }
                    Directory.CreateDirectory(baseFolderPath);


                    List<int> failedPages = new List<int>();

                    for (int i = 1; i <= step; i++)
                    {
                        pauseEvent.WaitOne();
                        if (!LoadDataFromUrl(i, failedPages))
                        {
                            failedPages.Add(i);
                        }
                    }
                    StatusText("Проверка целостности");

                    foreach (int page in failedPages)
                    {
                        pauseEvent.WaitOne();
                        if (!Directory.Exists(baseFolderPath))
                        {
                            Directory.CreateDirectory(baseFolderPath);
                        }
                        StatusText($"Докачка и восстановление тома №{page}");
                        LoadDataFromUrl(page, null);
                    }
                    StatusText("Восстановление завершено");
                }
                else
                {
                    cconvert = false;
                    StatusText("Имеются данные. Загрузка проигнорирована");
                    dataLoader.CancelAsync();
                }
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }
        private bool LoadDataFromUrl(int page, List<int> failedPages)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    statis.Text = $"Загрузка {page} / {step} тома. \nВ томе до {numericUpDown1.Value} значений. \nВсего: {label23.Text} значений";
                    Tools.NotivState(notify, $"Загрузка: {page} из {step}");
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
                                    ostalos.Text = Tools.Ostalos(page, Convert.ToInt32(step), startJop);
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
                Tools.MessageShow(notify, "Ошибка", message, 5);
            });
        }
        private void dataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StatusText("Загрузка данных завершена");
            progressBar1.Value = 0;
            progressBar2.Value = 0;

            if (cconvert)
            {
                convertToCSV.RunWorkerAsync();
            }
            else
            {
                convertToSQL.RunWorkerAsync();
            }

        }
        #endregion Загрузчик

        #region Экспорт в CSV
        public string exporturl = "";
        private void convertToCSV_DoWork(object sender, DoWorkEventArgs e)
        {
            startJop = DateTime.Now;
            StatusText("Конвертация данных в CSV");
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            try
            {
                string exportPath = Path.Combine(".//data", oid_l.Text);
                CreateDirectoryIfNotExists(exportPath);
                string versionFolderPath = Path.Combine(exportPath, version_l.Text);
                if (Directory.Exists(versionFolderPath))
                {
                    Directory.Delete(versionFolderPath, true);
                }
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
                StatusText("Проверка целостнности");
                RetryFailedFiles(failedIndexes, versionFolderPath);
                StatusText($"Экспорт завершён");
                Tools.MessageShow(notify, "Успешно", "Экспорт завершён", 5);
            }
            catch (Exception ex)
            {
                HandleExportError(ex);
            }
        }
        private void HandleExportError(Exception ex)
        {
            Sv.Log(ex.Message, ex.StackTrace);
            Tools.MessageShow(notify, "Ошибка", "Произошла ошибка: " + ex.Message, 5);
        }
        private void RetryFailedFiles(List<int> failedIndexes, string versionFolderPath)
        {
            foreach (int index in failedIndexes)
            {
                pauseEvent.WaitOne();
                StatusText($"Повторная попытка экспорта тома №{index}");
                ExportJsonToCsv(index, versionFolderPath);
            }
            StatusText("Восстаноление завершено");
        }
        private bool ExportJsonToCsv(int index, string versionFolderPath)
        {
            StatusText($"Конвертация в CSV: {index} из {step}");
            ostalos.Text = Tools.Ostalos(index, Convert.ToInt32(step), startJop);
            string jsonFilePathtemp = Path.Combine(".//temp", oid_l.Text);
            string jsonFilePath = Path.Combine(jsonFilePathtemp, $"data_{index}.json");
            string csvFilePath = Path.Combine(versionFolderPath, $"data_{index}.csv");
            progressBar1.Value = Convert.ToInt32((index * 100) / step);
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
                Tools.MessageShow(notify, "Ошибка", "Не удалось экспортировать данные", 5);
                return false;
            }
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
        private void convertToCSV_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StatusText("Конвертация данных в CSV завершена");
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            dataLoader.CancelAsync();
            convertToSQL.RunWorkerAsync();
        }
        public class ColumnValue
        {
            public string column { get; set; }
            public string value { get; set; }
        }
        #endregion Экспорт в CSV

        #region Экспорт в SQL
        private void convertToSQL_DoWork(object sender, DoWorkEventArgs e)
        {
            startJop = DateTime.Now;
            StatusText("Конвертация данных в SQL");
            try
            {
                Tools.MessageShow(notify, "Загрузка", "Запущен экспорт в SQL", 5);
                StatusText($"Запущен экспорт в SQL");
                string sourcePath = $@".\data\{oid_l.Text}\{version_l.Text}";
                string destinationPath = $@".\dump_sql\{oid_l.Text}\{version_l.Text}\";
                if (Directory.Exists(destinationPath))
                {
                    Directory.Delete(destinationPath, true);
                }
                ExportSql(sourcePath, destinationPath, oid_l.Text);
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }
        public void ExportSql(string folderPath, string outputFolderPath, string tableName)
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
                        ProcessCsvFile(csvFilePath, outputFolderPath, tableName);
                        UpdateProgress(io++, csvFiles.Length);
                    }
                    catch (Exception ex)
                    {
                        failedFiles.Add(csvFilePath);
                        Tools.MessageShow(notify, "Ошибка", $"Ошибка при обработке файла: {csvFilePath} - {ex.Message}", 5);
                    }
                }
                RetryFailedFiles(failedFiles, outputFolderPath, tableName);
            }
            catch (Exception ex)
            {
                Tools.MessageShow(notify, "Ошибка!", "Ошибка при загрузке папок: " + ex.Message, 5);
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }
        private void UpdateProgress(int current, int total)
        {
            StatusText($" Конвертация в SQL: {current} из {total}");
            int percentComplete = (int)((current * 100) / total);
            progressBar1.Value = percentComplete;
            ostalos.Text = Tools.Ostalos(current, total, startJop);
        }
        private void RetryFailedFiles(List<string> failedFiles, string outputFolderPath, string tableName)
        {
            foreach (string failedFile in failedFiles)
            {
                pauseEvent.WaitOne();
                try
                {
                    ProcessCsvFile(failedFile, outputFolderPath, tableName);
                    StatusText($"Повторная подготовка скриптов для: {failedFile}");
                }
                catch (Exception ex)
                {
                    Tools.MessageShow(notify, "Ошибка", $"Ошибка при повторной обработке файла: {failedFile} - {ex.Message}", 5);
                }
            }
        }
        public string pathsql;
        private void ProcessCsvFile(string csvFilePath, string outputFolderPath, string tableName)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(csvFilePath);
            string sqlFilePath = Path.Combine(outputFolderPath, fileNameWithoutExtension + ".sql");
            pathsql = sqlFilePath;
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

                    string insertStatement = GenerateInsertStatement(tableName, columns, values);
                    sw.WriteLine(insertStatement);
                }
            }
        }
        private string[] ProcessHeaderLine(string headerLine)
        {
            return headerLine.Split('|').Select(column => string.IsNullOrEmpty(column) ? "NULL" : "\"" + column.Replace("\"", "") + "\"").ToArray();
        }
        private string[] ProcessDataLine(string line)
        {
            return line.Split('|').Select(value => string.IsNullOrEmpty(value) ? "NULL" : "'" + value.Replace("\"", "") + "'").ToArray();
        }

        public string GenerateInsertStatement(string tableName, string[] columns, string[] values)
        {
            string columnsPart = string.Join(", ", columns);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Tools.ToData(values[i]);
            }
            string valuesPart = string.Join(", ", values);
            return $"INSERT INTO \"{config.Shema}\".\"{tableName}\" ({columnsPart}) VALUES ({valuesPart});";
        }

        private void convertToSQL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            convertToSQL.CancelAsync();
            StatusText("Конвертация данных в SQL завершена. Подготовка к загрузке");
            Tools.MessageShow(notify, "Скрипты готовы к загрузке", $"Загрузка скриптов справочника {oid_l.Text} в БД", 5);
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            checktableLoader.RunWorkerAsync();
        }
        #endregion Экспорт в SQL

        #region Проверка таблиц
        private void checktableLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            StatusText("Проверка таблицы на наличие записей");
            check();
        }
        public void check()
        {
            try
            {
                string tablecheck = $"TRUNCATE TABLE {config.Shema}.\"{oid_l.Text}\" CONTINUE IDENTITY RESTRICT;";
                Tools.sqlcommand(tablecheck);
                StatusText("Таблица проверена");
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                StatusText(ex.Message);
            }
        }
        private void checktableLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            uploadLoader.RunWorkerAsync();
            StatusText("Загрузка данных в SQL завершена.");
        }

        #endregion Проверка таблиц

        #region Загрузчик SQL
        private void loadsqlButton_Click_1(object sender, EventArgs e)
        {
            uploadLoader.RunWorkerAsync();
        }
        private void uploadLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            startJop = DateTime.Now;
            string sourcePath = $@".\dump_sql\{oid_l.Text}\{version_l.Text}";
            string[] sqlFiles = Directory.GetFiles(sourcePath, "*.sql");
            int File = 1;
            foreach (string sqlPath in sqlFiles)
            {
                pauseEvent.WaitOne();
                try
                {
                    if (Tools.ImportToPGSQL(sqlPath))
                    {
                        statis.Text = $"Файл {sqlPath} загружен";
                    }
                    else
                    {
                        statis.Text = $"Ошибка при загрузке {sqlPath}";
                        goodJop = false;
                    }
                }
                catch (Exception ex)
                {
                    Sv.Log(ex.Message, ex.StackTrace);
                }
                ostalos.Text = Tools.Ostalos(File, Convert.ToInt32(sqlFiles.Length), startJop);
                File++;
            }
        }

        public void EndWorker()
        {
            if (Jops)
            {
                StatusText($"Отправка уведомления в Telegram");
                datenowend = Tools.GetNawDate().ToString("HH:mm:ss dd-MM-yyyy");
                string status = goodJop ? "Успешно." : $"Загрузка не удалась. Информацию можете узнать в логах.";
                string message = $"Наименование:\n{fullName.Text}\nOID:\n{oid_l.Text}\nВерсия:\n{version_l.Text}\nЗапущен:\n{datestart}\nЗавершен:\n{datenowend}\n===================\nДоп. информация:\n{status}";
                Tools.tgbot(message);
            }
            Jops = false;
            startButton.Enabled = true;
            numericUpDown1.Enabled = true;
            buttonPauseResume.Enabled = false;
            closeJop.Enabled = false;
            versionBox.Enabled = true;
            StatusText("Загрузка завершена");
            if (goodJop)
            {
                string sourcePath1 = $@".\data\{oid_l.Text}";
                string sourcePath2 = $@".\dump_sql\{oid_l.Text}";
                try
                {
                    Directory.Delete(sourcePath1, true);
                    Directory.Delete(sourcePath2, true);
                }
                catch (Exception ex)
                {
                    Sv.Log(ex.Message, ex.StackTrace);
                }
            }
        }

        private void uploadLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EndWorker();
        }
        #endregion Загрузчик SQL

        #region Боковые кнопки
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Tools.MessageShow(notify, "Фоновый режим", $"Окно \"{this.Text}\" переведено в фоновый режим", 5);
            MainView view = new MainView();
            view.Show();
            this.Hide();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string exportPathtemp = Path.Combine(@".\data\", oid_l.Text);
            string exportPath = Path.Combine(exportPathtemp, version_l.Text);
            Tools.OpenFolder(exportPath);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ConfigSQL view = new ConfigSQL();
            view.ShowDialog();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Sv.createdlogfiles();
            System.Diagnostics.Process txt = new System.Diagnostics.Process();
            txt.StartInfo.FileName = "notepad.exe";
            txt.StartInfo.Arguments = Sv.ErrorLogFile;
            txt.Start();
        }
        #endregion Боковые кнопки

        #region Уведомления
        private void notify_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
        private void notify_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
        private void notify_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
        #endregion Уведомления

        public void StatusText(string status)
        {
            statis.Text = status;
            Tools.NotivState(notify, status);
        }
    }
}
