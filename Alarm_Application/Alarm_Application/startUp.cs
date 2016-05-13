using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alarm_Application.Properties;

namespace Alarm_Application
{
    public partial class startUp : Form
    {
        public startUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submit();
            }
        }
        private void submit()
        {
            if(txtName.Text != "")
            {
                Settings.Default.username = txtName.Text;
                DialogResult = DialogResult.OK;   
            }
            else
            {
                MessageBox.Show("Enter your name in the textbox", "Error");
            }
        }
    }
}
