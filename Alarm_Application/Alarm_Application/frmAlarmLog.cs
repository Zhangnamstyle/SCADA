using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Alarm_Application
{
    public partial class frmAlarmLog : Form
    {
        DataTable tblAllAlarms;
        public frmAlarmLog()
        {
            InitializeComponent();
            setupDGV();
            using (var mainForm = new frmAlarmList())
            {
                tblAllAlarms = mainForm.logData();
                dgvAlarmLog.DataSource = tblAllAlarms;
                tmrUpdate.Start();
            }
            
        }

        private void setupDGV()
        {
            dgvAlarmLog.AllowUserToAddRows = false;
            dgvAlarmLog.ReadOnly = true;
        }

        private void frmAlarmLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(frmAlarmList.logForm != null)
            {
                frmAlarmList.logForm = null;
            }
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            using (var mainForm = new frmAlarmList())
            {
                tblAllAlarms = mainForm.logData();
                dgvAlarmLog.DataSource = tblAllAlarms;
            }
        }
    }
}
