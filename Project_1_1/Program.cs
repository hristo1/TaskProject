using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1_1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
           
            
            //frmLogin loginForm = new frmLogin();
            //DialogResult loginResult = loginForm.ShowDialog();

            //if (loginResult == DialogResult.OK)
            //{
            //    Application.Run(new frmMain());
            //}
        }
    }
}
