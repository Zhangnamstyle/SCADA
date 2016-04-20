using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SCADA_Control_Application
{
    public class OPC
    {
        private string opcConURL;

        public OPC(string opcURL)
        {
            this.opcConURL = opcURL;
        }

        public void writeToOPC(double opcValue)
        {
            
        }
    }
}
