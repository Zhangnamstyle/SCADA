using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.Net;

namespace DataLogging_Application
{
    public class OPC
    {
        private int tId { get; set; }
        private string itURL { get; set; }
        private string tName { get; set; }
        private string itID { get; set; }
        private string opcQuality { get; set; }
        private string opcStatus { get; set; }

        
        public OPC(int tagID,string tagName,string itemID,string itemUrl)
        {
            tId = tagID;
            itURL = itemUrl;
            tName = tagName;
            itID = itemID;
            opcQuality = "Unknown";
            opcStatus = "Active";
        }
        public OPC(string itemURL)
        {
            itURL = itemURL;
        }
        public int getTagID()
        {
            return tId;
        }
        public string getQuality()
        {
            return opcQuality;
        }
        public string getStatus()
        {
            return opcStatus;
        }
        public double readFromOPC()
        {
            double OPCvalue = 0;
            try
            {
                using (DataSocket ds = new DataSocket())
                {
                    ds.Connect(itURL, AccessMode.Read);
                    ds.Update();
                    OPCvalue = Convert.ToDouble(ds.Data.Value);
                    opcQuality = ds.Data.Attributes["Quality"].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                OPCvalue = 998;
            }
            return OPCvalue;
        }

        public void writeToOPC(bool opcValue)
        {

            using (DataSocket ds = new DataSocket())
            {
                ds.Connect(itURL, AccessMode.Write);
                ds.Data.Value = opcValue;
                ds.Update();
            }

        }
    }
}
