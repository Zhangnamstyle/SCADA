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
        static string opcBoolURL = "opc://localhost/Matrikon.OPC.Simulation/Bucket Brigade.Boolean";
        OPC testOPC = new OPC(opcBoolURL);
       
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

            timer1.Start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                setOPC();
                string conUrl = "opc://localhost/Matrikon.OPC.Simulation/Bucket Brigade.Real4";

                OPC myOPC = new OPC(conUrl);
                string val = myOPC.readFromOPC();
                txtBxOpcVal.Text = val;

                using (SqlConnection con = new SqlConnection(Settings.Default.conString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO TEST(TestTime,TestValue) VALUES (getdate(),@VALUE)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@VALUE", Convert.ToDouble(val));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string conUrl = "opc://localhost/Matrikon.OPC.Simulation/Tags.Temperature";

            OPC myOPC = new OPC(conUrl);
            myOPC.writeToOPC(Convert.ToDouble(textBox1.Text.ToString()));
        }

           private void setOPC()
        {
            
            testOPC.writeToOPC(true);
        }
        private void CreateOPC()
        {
            //READ FROM CSV FILE TAGS.
            //FOR ...


        }
        
    }
}
