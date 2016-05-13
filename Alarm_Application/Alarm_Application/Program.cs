using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm_Application
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
            using (var startup = new startUp())
            {
                startup.StartPosition |= FormStartPosition.CenterScreen;
                DialogResult result = startup.ShowDialog();
                if(result == DialogResult.OK)
                {
                    Application.Run(new frmAlarmList());
                }
                
            }
                
        }
    }
}
