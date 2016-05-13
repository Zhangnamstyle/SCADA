using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NationalInstruments;
using NationalInstruments.Net;
using System.Windows.Forms;

namespace SCADA_Control_Application
{
    class OPC
    {
        private int tId { get; set; }
        private string itURL { get; set; }
        private string tName { get; set; }
        private string itID { get; set; }


        public OPC(int tagID, string tagName, string itemID, string itemUrl)
        {
            tId = tagID;
            itURL = itemUrl;
            tName = tagName;
            itID = itemID;
        }
        public OPC(string itemURL)
        {
            this.itURL = itemURL;
        }

        public void writeToOPC(double temperature,double u)
        {
            try
            {
                using (DataSocket ds = new DataSocket())
                {
                    if (ds.IsConnected) ds.Disconnect();
                    if (tName == "Temperature")    
                    {
                        ds.Data.Value = temperature;
                    }
                    else if (tName == "Control")
                    {
                        ds.Data.Value = u;
                    }
                    ds.Connect(itURL, AccessMode.Write);
                    ds.Update();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void writeToOPC(bool opcValue)
        {
            using (DataSocket ds = new DataSocket())
            {
                if (ds.IsConnected) ds.Disconnect();
                var temp = opcValue;
                ds.Connect(itURL, AccessMode.Write);
                ds.Data.Value = temp;
                ds.Update();
            }
        }
        public bool readFromOPC()
        {
            bool OPCvalue = false;
            using (DataSocket ds = new DataSocket())
            {
                ds.Connect(itURL, AccessMode.Read);
                ds.Update();
                OPCvalue = Convert.ToBoolean(ds.Data.Value);
            }

            return OPCvalue;
        }
        
    }
    }

