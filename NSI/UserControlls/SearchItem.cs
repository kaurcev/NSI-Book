using NSI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSI.UserControlls
{
    public partial class SearchItem : UserControl
    {
        public static string oid { get; set; }
        public static string version { get; set; }
        public static string fullName { get; set; }
        public static string description { get; set; }
        public static string createDate { get; set; }
        public static string publishDate { get; set; }
        public static string lastUpdate { get; set; }
        public static bool archive { get; set; }
        public SearchItem()
        {
            InitializeComponent();
        }

        private void SearchItem_Load(object sender, EventArgs e)
        {
            oid_l.Text = Tools.Fix(oid);
            version_l.Text = Tools.Fix(version);
            fullName_l.Text = Tools.Fix(fullName);
            description_l.Text = Tools.Fix(description);
            createDate_l.Text = Tools.Fix($"Создан: {createDate}");
            publishDate_l.Text = Tools.Fix($"Опубликован: {publishDate}");
            lastUpdate_l.Text = Tools.Fix($"Обновлён: {lastUpdate}");
            flowLayoutPanel4.Visible = archive;
        }

        private void fullName_l_Click(object sender, EventArgs e)
        {
            ExportView view = new ExportView();
            ExportView.oid = oid_l.Text;
            ExportView.version = version_l.Text;
            view.Show();
        }
    }
}
