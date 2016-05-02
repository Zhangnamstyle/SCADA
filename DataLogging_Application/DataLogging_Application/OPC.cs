using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.Net;

namespace DataLogging_Application
{
    class OPC
    {
        private string opcConUrl;
        public OPC(string opcUrl)
        {
            this.opcConUrl = opcUrl;
        }
        
        public string readFromOPC()
        {
            string OPCvalue = "";
            using (DataSocket ds = new DataSocket()) 
            {
                ds.Connect(opcConUrl, AccessMode.Read);
                ds.Update();
                OPCvalue = Convert.ToString(ds.Data.Value);
            }
                

            return OPCvalue;
        }
        public void writeToOPC(double opcValue)
        {
            
            using (DataSocket ds = new DataSocket())
            {
                ds.Connect(opcConUrl, AccessMode.Write);
                ds.Data.Value = opcValue;
                ds.Update();
            }

        }
        public void writeToOPC(bool opcValue)
        {

            using (DataSocket ds = new DataSocket())
            {
                ds.Connect(opcConUrl, AccessMode.Write);
                ds.Data.Value = opcValue;
                ds.Update();
            }

        }
    }
}
