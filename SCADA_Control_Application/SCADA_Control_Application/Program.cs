using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCADA_Control_Application
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
            using (var startUpForm = new frmStartUp())
            {
                
                DialogResult result = startUpForm.ShowDialog();
                if(result == DialogResult.No)
                {
                    Application.Run(new frmHIL());
                }

                else if(result == DialogResult.OK)
                {
                    Application.Run(new frmLogging());
                }
                else
                {
                    Application.Run(new frmSimulation());
                }
            }
                

           
        }
    }
   
}
