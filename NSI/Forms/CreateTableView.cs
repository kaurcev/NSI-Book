﻿using Newtonsoft.Json.Linq;
using NSI.Classes;
using NSI.Classes.Postgresql;
using NSI.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            flowLayoutPanel1.Visible = true;
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
                    ColumnItem.namehead = header;
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
            button1.Enabled = true;
            foreach (string header in columns)
            {
                string head = "";
                switch (combi[header].Type)
                {
                    case ("UUID"): head = "UUID"; break;
                    case ("Целое число (INTEGER)"): head = "integer"; break;
                    case ("Целое число (BIGINT)"): head = "bigint"; break;
                    case ("Дробное число"): head = "real"; break;
                    case ("Текст"): head = "varchar"; break;
                    case ("Да/нет"): head = "boolean"; break;
                    case ("Дата"): head = "date"; break;
                    default: break;

                }
                if (checkBox1.Checked && header == comboBox1.Text)
                {
                    columnDefinitions.Add($"\"{header}\" {head} PRIMARY KEY");
                }
                else
                {
                    columnDefinitions.Add($"\"{header}\" {head}");
                }
            }
            string tableName = label1.Text;
            string createTableScript = $"CREATE TABLE \"{config.Shema}\".\"{tableName}\" (\n{string.Join(",\n", columnDefinitions.ToArray())}\n);\n";
            string comment = $"COMMENT ON TABLE \"{config.Shema}\".\"{tableName}\" IS 'OID Справочника : {OID}; Дата создания: {DateTime.Now:yyyy-MM-dd HH:mm:ss}.';";
            string finalScript = createTableScript + comment;
            label4.Text = finalScript;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlcommandLoader.RunWorkerAsync();
        }
        private void sqlcommandLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Tools.checktable(label1.Text))
                {
                    Tools.sqlcommand($"DROP TABLE {config.Shema}.\"{label1.Text}\";");
                }
                Tools.sqlcommand(label4.Text);
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }

        private void sqlcommandLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Команда была выполнена");
            button1.Enabled = false;
        }

        private void CreateTableView_FormClosed(object sender, FormClosedEventArgs e)
        {
            headerLoader.CancelAsync();
            sqlcommandLoader.CancelAsync();
            Tools.DeadApp();
        }
    }
}