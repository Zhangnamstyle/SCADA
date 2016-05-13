using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataLogging_Application
{
    public partial class frmTagConfig : Form
    {
        DataTable dt;
        public frmTagConfig()
        {
            InitializeComponent();
            dt = new DataTable();
            string querry = "SELECT * FROM TAGCONFIGURATION";
            dt = dbComm.fillTable(querry);
            dgvTagConfig.DataSource = dt;

            dgvTagConfig.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTagConfig.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTagConfig.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTagConfig.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTagConfig.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = dgvTagConfig.CurrentCell.RowIndex;
            
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            dbComm.updateTable(dt);
            writeTagsToFIle(dt);
            DialogResult = DialogResult.OK;
        }
        private void writeTagsToFIle(DataTable tbl)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = "opcTags.txt";
                string filePath = Path.Combine(path, fileName);
                string tagTxt = dtToString(tbl);
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(tagTxt);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static string dtToString(DataTable tbl)
        {
            StringBuilder sb = new StringBuilder();
            char seperator = ',';
            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    string value = null;
                    for (int i = 0; i < tbl.Columns.Count; i++)
                    {
                        value = row[i].ToString();
                        if (value.Contains(","))
                        {
                            value = value.Replace(",", ".");
                        }
                        sb.Append(value);
                        if (i < tbl.Columns.Count - 1)
                        {
                            sb.Append(seperator);
                        }
                    }
                    sb.AppendLine();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sb.ToString();

        }
    }
}
