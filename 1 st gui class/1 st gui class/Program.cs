using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_st_gui_class
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
            // Form1 f1 = new Form1();
            //  Application.Run(f1);
            //Application.Run(new MainWindow());
            Application.Run(new CostomerForm());
            /* Form3 f3 = new Form3();
             Application.Run(f3);*/
            /*Form4 f4 = new Form4();
            Application.Run(f4);*/
            //Application.Run(new Form2());
        }
    }
}
