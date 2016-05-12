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
        private bool first;
        DataTable tbl = new DataTable();
        public Form1()
        {
            InitializeComponent();
            tbl = new DataTable();
            tmr.Start();
            first = true;

        }
        
        private DataTable getAlarm()
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT * FROM dbo.ALARM";
            string connectionString = Settings.Default.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(cmd, con))
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dt);
                }
                con.Close();
            }
            

            return dt;
        }
        private void acknowledgeAlarm(int alarmID)
        {

            string cmd = "UPDATE dbo.ALARM SET AcknowledgeTime = @time, AcknowledgePerson = @person WHERE AlarmID = @Aid";
            SqlCommand command = new SqlCommand();
            command.CommandText = cmd;
            command.Parameters.AddWithValue("@time", DateTime.Now);
            command.Parameters.AddWithValue("@person","Kim");
            command.Parameters.AddWithValue("@Aid", 1);
            string connectionString = Settings.Default.ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                command.Connection = con;
                    command.ExecuteNonQuery();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            tbl = getAlarm();
            if (first == true)
            {
                DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                dataGridView1.Columns.Add(check);
                first = false;
                
            }
            int rowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tbl;
            dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 

                acknowledgeAlarm(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }
    }
}
