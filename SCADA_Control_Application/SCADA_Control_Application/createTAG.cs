using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SCADA_Control_Application
{
    static class createTAG
    {
        public static OPC[] creatOPCTags()
        {
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "opcTags.txt";
            string filePath = Path.Combine(path, fileName);
            OPC[] tagObj = new OPC[File.ReadAllLines(filePath).Length];
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int count = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        int tagID = Convert.ToInt16(data[0]);
                        string tagName = data[1].ToString();
                        string ItemID = data[2].ToString();
                        string itemUrl = data[3].ToString();
                        tagObj[count] = new OPC(tagID, tagName, ItemID, itemUrl);
                        count++;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tagObj;
        }

    }
}
