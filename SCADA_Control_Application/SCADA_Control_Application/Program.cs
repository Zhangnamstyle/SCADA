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
        public static bool error { get; set; }
        public static bool opcE { get; set; }
        public static bool daqE { get; set; }
        [STAThread]
        static void Main()
        {
            ///Boolean values used in other forms for indicating error when running
            error = false;
            opcE = false;
            daqE = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /// Using frmStartUp to choose what mode to run the application in
            using (var startUpForm = new frmStartUp())
            {
                //The result of the dialogResult is used to choose what form to run. 
                DialogResult result = startUpForm.ShowDialog();
                if (result == DialogResult.No)
                {
                    Application.Run(new frmHIL());
                }

                else if (result == DialogResult.OK)
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
   