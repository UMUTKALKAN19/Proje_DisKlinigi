using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Proje_DisKlinigi
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //string processName = Process.GetCurrentProcess().ProcessName;
            //Process[] processesByName = Process.GetProcessesByName(processName);

            //if (processesByName.Length > 1)
            //{
            //    MessageBox.Show("Program zaten açık.");
            //    return;
            //}



            Application.Run(new FrmGirisler());
        }
    }
}
