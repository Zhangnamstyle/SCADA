using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCADA_Control_Application.Properties;

namespace SCADA_Control_Application
{
    public partial class frmStartUp : Form
    {
        public bool test = false;
        public frmStartUp()
        {
            InitializeComponent();
            string dev = Settings.Default.DevName.ToString();
            txtDevName.Text = dev;
            rdbSim.Checked = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.DevName = txtDevName.Text.ToString();
            Settings.Default.Save();
            if(rdbSim.Checked)
            {
                DialogResult = DialogResult.Yes;
            }
            if(rdbHil.Checked)
            {
                DialogResult = DialogResult.No;
            }
            if(rdbLog.Checked)
            {
                DialogResult = DialogResult.OK;
            }
        }

       
    }
}
