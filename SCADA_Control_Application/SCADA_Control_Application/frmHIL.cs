using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCADA_Control_Application
{
    public partial class frmHIL : Form
    {
        private double temp;
        private double u;
        private int count;
        int cntTest = 0;
        int cntOPCTest = 0;
        static bool lastTest = false;

        OPC test;
        static string opcBoolURL = "opc://localhost/Matrikon.OPC.Simulation/Bucket Brigade.Boolean";
        OPC testOPC = new OPC(opcBoolURL);

        public frmHIL()
        {
            InitializeComponent();
            initParam();

        }
        private void initParam()
        {
            Simulator.envTemp = 21;
            Simulator.Kh = 3.87;
            Simulator.Tdly = 1.8571;
            Simulator.Ts = 0.5;
            Simulator.ThetaT = 15.3089;
            Simulator.N = Simulator.calcN();
            Simulator.Tout_k = Simulator.envTemp;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
