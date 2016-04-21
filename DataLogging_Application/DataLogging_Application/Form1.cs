using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using DataLogging_Application.Properties;

namespace DataLogging_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string conUrl = "";
            OPC myOPC = new OPC(conUrl);
            string val = myOPC.readFromOPC();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string conUrl = "opc://KIM-PC/Matrikon.OPC.Simulation/Bucket Brigade.Real4";

                OPC myOPC = new OPC(conUrl);
                string val = myOPC.readFromOPC();
                txtBxOpcVal.Text = val;

                using (SqlConnection con = new SqlConnection(Settings.Default.conString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO TEST(TestID) VALUES (@ID)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ID", val);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
