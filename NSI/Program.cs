using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NSI.Forms;

namespace NSI
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WelcomeView());
        }
    }
}
