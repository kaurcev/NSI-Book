using NSI.Classes;
using System;
using System.Windows.Forms;

namespace NSI.Forms
{
    public partial class WelcomeView : Form
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void WelcomeView_Load(object sender, EventArgs e)
        {
            label4.Text = Application.ProductVersion;
            label2.Text = Application.CompanyName;
            Tools.MessageShow(notify, "Добро пожаловать!", $"Здравствуйте {Environment.UserName}!", 5);
            Tools.NotivState(notify, "Двойным нажатием можете сразу закрыть программу");
        }
        private void ShowMainView()
        {
            MainView view = new MainView();
            view.Show();
            this.Hide();
        }

        private void WelcomeView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tools.DeadApp();
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void notify_MouseClick(object sender, MouseEventArgs e)
        {
            MainView mainView = new MainView();
            mainView.Show();
            WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowMainView();
            timer1.Stop();
        }
    }
}
