using NSI.Classes;
using System;
using System.Windows.Forms;

namespace NSI.UserControlls
{
    public partial class ColumnItem : UserControl
    {
        public static Combi combi;
        public static string namehead;
        public ColumnItem()
        {
            InitializeComponent();
        }

        private void ColunmItem_Load(object sender, EventArgs e)
        {
            label1.Text = namehead;
            comboBox1.SelectedIndex = 4;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            namehead = comboBox1.Text;
            combi[label1.Text].Type = comboBox1.Text;
        }
    }
}
