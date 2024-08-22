using Newtonsoft.Json.Linq;
using NSI.Classes;
using NSI.Classes.Postgresql;
using NSI.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace NSI.Forms
{
    public partial class CreateTableView : Form
    {
        private DatabaseConfig config = ConfigManager.GetDatabaseConfig();
        public static Combi combi = new Combi();
        public static string OID { get; set; }
        public static string NOTE { get; set; }
        public static string VERSION { get; set; }
        private string DemoJson;
        private List<string> columns;
        private List<string> columnDefinitions;

        public CreateTableView()
        {
            InitializeComponent();
        }

        private void CreateTableView_Load(object sender, EventArgs e)
        {
            label1.Text = OID;
            label2.Text = VERSION;
            label3.Text = NOTE;
            Tools.Title(this, $"Создание таблицы для {label1.Text} v{label2.Text}");
            headerLoader.RunWorkerAsync();
        }
        private string GetDemoDataUrl(string oid, string version)
        {
            return $"http://{Tools.NSIServer}/port/rest/data?userKey={Tools.userKey}&identifier={oid}&version={version}&page=1&size=1";
        }

        private void headerLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string url = GetDemoDataUrl(label1.Text, label2.Text);
                DemoJson = Tools.Fetch(url);
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                e.Result = ex;
            }
        }

        private void headerLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                flowLayoutPanel2.Controls.Clear();
                comboBox1.Items.Clear();
                JObject json = JObject.Parse(DemoJson);
                JArray list = (JArray)json["list"];
                columns = list[0].Select(item => (string)item["column"]).ToList();

                columnDefinitions = new List<string>();
                foreach (string header in columns)
                {
                    ColumnItem item = new ColumnItem();
                    ColumnItem.namehead  = header;
                    ColumnItem.combi = combi;
                    flowLayoutPanel2.Controls.Add(item);
                    comboBox1.Items.Add(header);
                }
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
                label4.Text = "Ошибка при обработке данных.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            columnDefinitions.Clear();
            foreach (string header in columns)
            {
                if (checkBox1.Checked && header == comboBox1.Text)
                {
                    columnDefinitions.Add($"\"{header}\" {combi[header].Type} PRIMARY KEY");
                }
                else
                {
                    columnDefinitions.Add($"\"{header}\" {combi[header].Type}");
                }
            }
            string tableName = label1.Text; 
            string createTableScript = $"CREATE TABLE \"{config.Shema}\".\"{tableName}\" (\n{string.Join(",\n", columnDefinitions.ToArray())}\n);\n";
            string comment = $"COMMENT ON TABLE \"{config.Shema}\".\"{tableName}\" IS 'OID Справочника : {OID}; Версия справочника: {VERSION}; Дата внесения: {DateTime.Now:yyyy-MM-dd HH:mm:ss}.';";
            string finalScript = createTableScript + comment;
            label4.Text = finalScript;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlcommandLoader.RunWorkerAsync();
        }
        private void sqlcommandLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Tools.sqlcommand(label4.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sqlcommandLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Команда была выполнена");
        }
    }
}