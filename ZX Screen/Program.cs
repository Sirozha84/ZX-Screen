using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZX_Screen
{
    static class Program
    {
        public static string Date = "08.12.2017";
        public static string Site = "www.sg-software.ru";
        public static string Url = "http://www.sg-software.ru";
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Count() > 0)
            {
                FormView view = new FormView(args[0]);
                view.ShowDialog();
                return;                
            }
            Application.Run(new FormMain());
        }
    }
}
