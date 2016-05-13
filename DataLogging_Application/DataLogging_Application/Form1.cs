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
        OPC[] opcTags;
       
        public Form1()
        {
            InitializeComponent();
            opcTags = createTags();

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
                int countOPC = 0;
                txtBxOpcVal.Text = "";
                foreach(OPC obj in opcTags)
                {
                    double tempVal = opcTags[countOPC].readFromOPC();
                    int tagID = opcTags[countOPC].getTagID();
                    string opcQuality = opcTags[countOPC].getQuality();
                    string opcStatus = opcTags[countOPC].getStatus();
                    SqlCommand cmd = new SqlCommand("EXECUTE NewTagItem @QUALITY,@TIMESTAMP,@VALUE,@TAGID,@STATUS");
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@QUALITY", opcQuality);
                    cmd.Parameters.AddWithValue("@TIMESTAMP", DateTime.Now);
                    cmd.Parameters.AddWithValue("@VALUE", tempVal);
                    cmd.Parameters.AddWithValue("@TAGID", tagID);
                    cmd.Parameters.AddWithValue("@STATUS", opcStatus);
                    dbComm.writeToDB(cmd);
                    txtBxOpcVal.AppendText("TagID: " + tagID.ToString() + " Value:" + tempVal.ToString() + "\r\n");
                    countOPC++;
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            createTags();
        }

           private void setOPC()
        {
            
            testOPC.writeToOPC(true);
            
        }
        public OPC[] createTags()
        {
            int tagCount = 0;
            string querry = "SELECT * FROM TAGCONFIGURATION";
            DataTable tbl = dbComm.fillTable(querry);
            OPC[] tagOBJ = new OPC[tbl.Rows.Count];
            for(int i = 0; i<tbl.Rows.Count;i++)
            {
                tagCount = i;
                int tagID = Convert.ToInt16(tbl.Rows[i]["TagID"]);
                string tagName = tbl.Rows[i]["TagName"].ToString();
                string itemID = tbl.Rows[i]["Itemid"].ToString();
                string itemUrl = tbl.Rows[tagCount]["ItemUrl"].ToString();
                tagOBJ[i] = new OPC(tagID,tagName,itemID,itemUrl);

            }
            return tagOBJ;
        }
       
     
    }
}
