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

        
        public OPC(int tagID,string tagName,string itemID,string itemUrl)
        {
            tId = tagID;
            itURL = itemUrl;
            tName = tagName;
            itID = itemID;
        }
        public OPC(string itemURL)
        {
            itURL = itemURL;
        }
        
        public string readFromOPC()
        {
            string OPCvalue = "";
            using (DataSocket ds = new DataSocket()) 
            {
                ds.Connect(itURL, AccessMode.Read);
                ds.Update();
                OPCvalue = Convert.ToString(ds.Data.Value);
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
