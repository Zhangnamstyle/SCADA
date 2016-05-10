using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCADA_Control_Application
{
    public partial class frmStartUp : Form
    {
        public bool test = false;
        public frmStartUp()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                DialogResult = DialogResult.Yes;
            }
            if(radioButton2.Checked)
            {
                DialogResult = DialogResult.No;
            }
            if(radioButton3.Checked)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
