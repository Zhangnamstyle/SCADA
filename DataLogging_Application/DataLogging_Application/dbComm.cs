using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLogging_Application.Properties;
using System.Windows.Forms;

namespace DataLogging_Application
{
    static class dbComm
    {
        public static void writeToDB(SqlCommand cmd)
        {
            using (SqlConnection con = new SqlConnection(Settings.Default.conString))
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static DataTable fillTable(string sqlQuery)
        {
            DataTable tbl = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(Settings.Default.conString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tbl);
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                
            }
            return tbl;
        }
        public static void updateTable(DataTable tbl)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Settings.Default.conString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TAGCONFIGURATION", con))
                    using (SqlCommandBuilder sqlCB = new SqlCommandBuilder(da))
                    {
                        da.Update(tbl);
                    }
                    con.Close();

                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }
    }
}
