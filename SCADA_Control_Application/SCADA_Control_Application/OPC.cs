using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NationalInstruments;
using NationalInstruments.Net;

namespace SCADA_Control_Application
{
    class OPC
    {
        private string opcURL;
        

        public OPC(string opcURL)
        {
            this.opcURL = opcURL;
        }

        public void writeToOPC(double opcValue)
        {
            using (DataSocket ds = new DataSocket())
            {
                if (ds.IsConnected) ds.Disconnect();
                var temp = opcValue;
                ds.Connect(opcURL,AccessMode.Write);
                ds.Data.Value = temp;
                ds.Update();
            }
        }
        public void writeToOPC(int opcValue)
        {
            using (DataSocket ds = new DataSocket())
            {
                if (ds.IsConnected) ds.Disconnect();
                var temp = opcValue;
                ds.Connect(opcURL, AccessMode.Write);
                ds.Data.Value = temp;
                ds.Update();
            }
        }
        public void writeToOPC(bool opcValue)
        {
            using (DataSocket ds = new DataSocket())
            {
                if (ds.IsConnected) ds.Disconnect();
                var temp = opcValue;
                ds.Connect(opcURL, AccessMode.Write);
                ds.Data.Value = temp;
                ds.Update();
            }
        }
        public bool readFromOPC()
        {
            bool OPCvalue = false;
            using (DataSocket ds = new DataSocket())
            {
                ds.Connect(opcURL, AccessMode.Read);
                ds.Update();
                OPCvalue = Convert.ToBoolean(ds.Data.Value);
            }

            return OPCvalue;
        }
    }
}
