using Newtonsoft.Json;
using NSI.Classes;
using NSI.Forms;
using NSI.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NSI
{
    public partial class MainView : Form
    {
        public static Responce responsed;
        public static int pagenum = 1;
        public MainView()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ConfigSQL view = new ConfigSQL();
            view.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tools.OpenFolder(@".\data\");
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tools.DeadApp();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            Tools.Title(this, "Добро пожаловать!");
            UserControl view = new WelcomeBanner();
            flowLayoutPanel1.Controls.Add(view);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !checkBox1.Checked;
            textBox2.Enabled = checkBox1.Checked;
            textBox2.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = checkBox2.Checked;
            dateTimePicker2.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = checkBox3.Checked;
        }
        public string SearchUrl(bool oids, bool dated, bool archive, bool sort)
        {
            var baseUrl = $"http://{Tools.NSIServer}/port/rest/searchDictionary?userKey={Tools.userKey}&page={pagenum}&size=15";
            var identifierOrName = oids ? $"&identifier={textBox2.Text}" : $"&name={textBox1.Text}";
            var url = $"{baseUrl}{identifierOrName}";
            if (dated)
            {
                var publishDateFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                var publishDateTo = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                url += $"&publishDateFrom={publishDateFrom}&publishDateTo={publishDateTo}";
            }
            if (archive)
            {
                url += "&showArchive=false";
            }
            if (sort)
            {
                var sortingDirection = comboBox1.SelectedIndex == 0 ? "ASC" : "DESC";
                url += $"&sortingDirection={sortingDirection}&sorting=fullName";
            }
            return url;
        }
        public void SearchGo()
        {
            try
            {
                var queryText = checkBox1.Checked ? Tools.Fix(textBox2.Text) : Tools.Fix(textBox1.Text);
                queryText = queryText != "Данные отсутствуют." ? queryText : null;
                if (queryText != null)
                {
                    flowLayoutPanel1.Controls.Clear();
                    UserControl view = new SearchBanner();
                    flowLayoutPanel1.Controls.Add(view);
                    Tools.Title(this, $"Поиск по запросу: \"{queryText}\""); ;
                    searchButton.Enabled = false;
                    searchLoader.RunWorkerAsync();
                    label2.Text = $"№{pagenum}";
                }
                else
                {
                    Tools.Title(this, $"Пустой запрос :D"); ;
                    statics.Text = "Пустой запрос :D";
                }
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (pagenum == 1)
            {
                MessageBox.Show("У тебя и так первая страница");
            }
            else
            {
                pagenum--;
                SearchGo();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pagenum++;
            SearchGo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pagenum = 1;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SearchGo();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pagenum = 1;
                SearchGo();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pagenum = 1;
                SearchGo();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pagenum = 1;
        }

        private void searchLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                statics.Text = "Отправляем запрос...";
                string url = SearchUrl(checkBox1.Checked, checkBox2.Checked, checkBox4.Checked, checkBox3.Checked);
                responsed = JsonConvert.DeserializeObject<Responce>(Tools.Fetch(url));
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }

        private void searchLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                statics.Text = "Формируем список...";
                flowLayoutPanel1.Controls.Clear();
                if (responsed.List.Count == 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                    UserControl view = new NotFoundBanner();
                    flowLayoutPanel1.Controls.Add(view);
                }
                foreach (var item in responsed.List)
                {
                    UserControl searchItem = new SearchItem();
                    SearchItem.fullName = item.fullName;
                    SearchItem.description = item.description;
                    SearchItem.version = item.version;
                    SearchItem.oid = item.oid;
                    SearchItem.createDate = item.createDate;
                    SearchItem.publishDate = item.publishDate;
                    SearchItem.lastUpdate = item.lastUpdate;
                    SearchItem.archive = item.archive;
                    flowLayoutPanel1.Controls.Add(searchItem);
                }
                statics.Text = $"Показаны {responsed.List.Count} справочников";
                searchButton.Enabled = true;
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                flowLayoutPanel1.Controls.Clear();
                var noFoundView = new ErrorJopBanner();
                flowLayoutPanel1.Controls.Add(noFoundView);
            }
        }
        public class Item
        {
            public string oid { get; set; }
            public string version { get; set; }
            public string fullName { get; set; }
            public string description { get; set; }
            public string createDate { get; set; }
            public string publishDate { get; set; }
            public string lastUpdate { get; set; }
            public bool archive { get; set; }
        }
        public class Responce
        {
            public string Result { get; set; }
            public List<Item> List { get; set; }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Sv.createdlogfiles();
            System.Diagnostics.Process txt = new System.Diagnostics.Process();
            txt.StartInfo.FileName = "notepad.exe";
            txt.StartInfo.Arguments = Sv.ErrorLogFile;
            txt.Start();
        }
    }
}