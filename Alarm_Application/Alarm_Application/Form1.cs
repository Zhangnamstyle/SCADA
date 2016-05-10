using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Alarm_Application.Properties;

namespace Alarm_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tmr.Start();
        }
        
        private void getAlarm()
        {
            DataTable tbl = new DataTable();
            string cmd = "SELECT * FROM dbo.TEST";
            string connectionString = Settings.Default.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(cmd, con))
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(tbl);
                }
                con.Close();
            }
            dataGridView1.DataSource = tbl;
         
        }
        private void acknowledgeAlarm()
        {

            string cmd = "INSERT INTO view_alarm (AcknowledgePerson,AcknowledgeTime) VALUES (" + textBox1.Text + ","  + DateTime.Now + ");";
            string connectionString = Settings.Default.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
               
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            getAlarm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }
    }
}
