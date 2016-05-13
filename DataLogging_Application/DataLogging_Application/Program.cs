using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLogging_Application
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
            using (var TagForm = new frmTagConfig())
            {
                DialogResult res = TagForm.ShowDialog();
                if(res == DialogResult.OK)
                {
                    Application.Run(new Form1());
                }
                
            }
        }
    }
}
