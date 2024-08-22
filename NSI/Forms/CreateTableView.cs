using NSI.Classes;
using NSI.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace NSI.Forms
{
    public partial class CreateTableView : Form
    {
        public static Combi combi = new Combi();
        public static string OID { get; set; }
        public static string NOTE { get; set; }
        public static string VERSION { get; set; }
        public static string chema { get; set; }
        public CreateTableView()
        {
            InitializeComponent();
        }

        private void CreateTableView_Load(object sender, EventArgs e)
        {
            label1.Text = OID;
            label2.Text = VERSION;
            label3.Text = NOTE;
            textBox1.Text = chema;
            Tools.Title(this, $"Создание таблицы для {label1.Text} v{label2.Text}");
            test();
        }

        void test()
        {
            string csvFilePath = @".\data\" + label1.Text + "\\" + label2.Text + "\\data_1.csv";
            loadHeaders(csvFilePath);
        }
        public void loadHeaders(string csvFilePath)
        {
            try
            {
                List<string> headers = new List<string>();

                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        headers.AddRange(line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                    }
                }

                List<string> columnDefinitions = new List<string>();
                comboBox1.Items.Clear();
                flowLayoutPanel2.Controls.Clear();
                foreach (string header in headers)
                {
                    ColumnItem item = new ColumnItem();
                    ColumnItem.namehead = header;
                    ColumnItem.combi = combi;
                    flowLayoutPanel2.Controls.Add(item);
                    columnDefinitions.Add(string.Format($"\"{header}\" {combi[ColumnItem.namehead].Type}"));
                    comboBox1.Items.Add(header);
                }
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }

        void createtablevoid() {
            string basePath = @".\data\";
            string intermediatePath = Path.Combine(basePath, label1.Text);
            string csvFilePath = Path.Combine(intermediatePath, label2.Text + "\\data_1.csv");

            string destinationBasePath = @".\dump_sql_created\";
            string destinationIntermediatePath = Path.Combine(destinationBasePath, label1.Text);
            string destinationPath = Path.Combine(destinationIntermediatePath, label2.Text);

            string fixedText = Tools.Fix(label1.Text);
            string shemaText = Tools.Fix(textBox1.Text);

            GenerateCreateTableScript(csvFilePath, shemaText, fixedText, comboBox1.Text, label2.Text, destinationPath);
        }
        public void GenerateCreateTableScript(string csvFilePath, string shema, string tableName, string oid, string version, string outputFilePath)
        {
            try
            {
                List<string> headers = new List<string>();

                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        headers.AddRange(line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                    }
                }

                List<string> columnDefinitions = new List<string>();
                foreach (string header in headers)
                {
                    if (checkBox1.Checked && header == comboBox1.Text)
                    {
                        columnDefinitions.Add(string.Format("\"{0}\" {1} PRIMARY KEY", header, combi[header].Type));
                    }
                    else
                    {
                        columnDefinitions.Add(string.Format("\"{0}\" {1}", header, combi[header].Type));
                    }

                }

                string createTableScript = string.Format(
                    "CREATE TABLE \"{0}\".\"{1}\" (\n{2}\n);\n",
                    shema,
                    tableName,
                    string.Join(",\n", columnDefinitions.ToArray())
                );

                string comment = string.Format(
                    "COMMENT ON TABLE \"{0}\".\"{1}\" IS 'OID Справочника : {2}; Версия справочника: {3}; Дата внесения: {4}.';",
                    shema,
                    tableName,
                    oid,
                version,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                );

                string finalScript = createTableScript + comment;
                label4.Text = finalScript;

                if (!Directory.Exists(outputFilePath))
                {
                    Directory.CreateDirectory(outputFilePath);
                }
                string fullPath = Path.Combine(outputFilePath, "created.sql");
                pathcreated = fullPath;
                File.WriteAllText(fullPath, finalScript, Encoding.Default);
            }
            catch (Exception ex)
            {
                Sv.Log(ex.Message, ex.StackTrace);
            }
        }
        public string pathcreated;


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createtablevoid();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Tools.ImportToPGSQL(pathcreated));
        }
    }
}
