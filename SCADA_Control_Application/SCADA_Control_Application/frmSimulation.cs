using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments;

namespace SCADA_Control_Application
{
    public partial class frmSimulation : Form
    {
        private double temp;
        private double u;

        private int count;

        int cntTest = 0;
        int cntOPCTest = 0;
        static bool lastTest = false;

        OPC[] opcTags;
        static string opcBoolURL = "opc://localhost/Matrikon.OPC.Simulation/Bucket Brigade.Boolean";
        OPC testOPC = new OPC(opcBoolURL);

        public frmSimulation()
        {
            InitializeComponent();
            setupFRM();
            IOCom.deviceName = "Dev3";
 
            opcTags = createTAG.creatOPCTags();
            tmrCheck.Start();

        }


        private void setupFRM()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            Simulator.envTemp = 21;
            Simulator.Kh = 3.87;
            Simulator.Tdly = 1.8571;
            Simulator.Ts = 0.5;
            Simulator.ThetaT = 15.3089;
            Simulator.N = Simulator.calcN();
            Simulator.Tout_k = Simulator.envTemp;

            Controller.Kp = 1.20;
            Controller.Ti = 9;
            Controller.Sp = trackBar1.Value;
            Controller.Ts = 0.5;

            temp = Simulator.envTemp;
            u = 0;
            count = 1;

            trackBar1.Minimum = Convert.ToInt16(Simulator.envTemp);
            trackBar1.Maximum = 50;
            trackBar1.Value = 30;
            lblSetpoint.Text = trackBar1.Value.ToString();

            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            chart1.Series["Series1"].Color = Color.Red;
            chart1.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0}°C";


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cntTest++;
            u = Controller.PI(temp);
            
            temp = Simulator.sim(u);

            
            count++;
            if(cntTest >= 2)
            {
                int countOPC = 0;
                    foreach(OPC obj in opcTags)
                {
                    opcTags[countOPC].writeToOPC(temp, u);
                    countOPC++;
                }
                DateTime x = DateTime.Now;
                    chart1.Series["Series1"].Points.AddXY(x.ToLocalTime(),temp);
                    chart1.ResetAutoValues();
                    cntTest = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmrUpdate.Start();
            if(tmrCheck.Enabled == false)
            {
                tmrCheck.Start();
            }
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Controller.Sp = trackBar1.Value;
            lblSetpoint.Text = trackBar1.Value.ToString();

        }

        private void checkOPC()
        {
            bool test = testOPC.readFromOPC();

            if (!test)
            {

                cntOPCTest++;
                if (cntOPCTest >= 3)
                {
                    tmrUpdate.Stop();
                    tmrCheck.Stop();
                    MessageBox.Show("Error connecting to OPC", "ALARM");
                    while (!test)
                    {
                        test = testOPC.readFromOPC();
                    }
                    if (test)
                    {
                        tmrUpdate.Start();
                        tmrCheck.Start();
                    }

                    cntOPCTest = 0;
                }
            }
            if (test)
            {
                testOPC.writeToOPC(false);
            }
            if(test && !lastTest)
            {
                cntOPCTest = 0;
            }
            lastTest = test;
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            checkOPC();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrCheck.Stop();
            tmrUpdate.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
