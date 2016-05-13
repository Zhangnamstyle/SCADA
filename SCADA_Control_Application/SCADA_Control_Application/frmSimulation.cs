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
using SCADA_Control_Application.Properties;

namespace SCADA_Control_Application
{
    public partial class frmSimulation : Form
    {
        private double temp;
        private double u;
        

        OPC[] opcTags;
        OPC testOPC;

        public frmSimulation()
        {
            InitializeComponent();
            setUpFRM();
            testOPC = new OPC(Settings.Default.opcCheckURL);
            opcTags = opcHandler.creatOPCTags();
            tmrCheck.Start();
        }


        private void setUpFRM()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;



            Simulator.envTemp = Settings.Default.envTemp;
            Simulator.Kh = Settings.Default.Kh;
            Simulator.Tdly = Settings.Default.Tdly;
            Simulator.Ts = Settings.Default.Ts;
            Simulator.ThetaT = Settings.Default.ThetaT;
            Simulator.Tout_k = Simulator.envTemp;



            trbSp.Minimum = Convert.ToInt16(Simulator.envTemp);
            trbSp.Maximum = 50;
            trbSp.Value = 25;
            lblSetpoint.Text = trbSp.Value.ToString();

            Controller.Kp = Settings.Default.Kp;
            Controller.Ti = Settings.Default.Ti;
            Controller.Sp = trbSp.Value;
            Controller.Ts = Settings.Default.Ts;

            temp = Simulator.envTemp;
            u = 0;


            crtData.Series.Add("Series1");
            crtData.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtData.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            crtData.Series["Series1"].Color = Color.Red;
            crtData.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            crtData.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            crtData.ChartAreas[0].AxisY.LabelStyle.Format = "{0}°C";


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                u = Controller.PI(temp);
                temp = Simulator.sim(u);
                int countOPC = 0;
                foreach (OPC obj in opcTags)
                {
                    opcTags[countOPC].writeToOPC(temp, u);
                    countOPC++;
                }
                DateTime x = DateTime.Now;
                crtData.Series["Series1"].Points.AddXY(x.ToLocalTime(), temp);
                crtData.ResetAutoValues();
                if (Program.error) stop();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
 
            private void stop()
        {
            tmrUpdate.Stop();
            tmrCheck.Stop();

            if (Program.opcE) MessageBox.Show("Opc Server or Datalogger is not running, System has stopped", "Error");
            if (Program.daqE) MessageBox.Show("An DAQ error has occurrd, System has stopped", "Error");

            btnStart.Enabled = true;
            btnStop.Enabled = false;
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
            Controller.Sp = trbSp.Value;
            lblSetpoint.Text = trbSp.Value.ToString();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bool test = testOPC.readFromOPC();
            opcHandler.checkOPC(test);
            testOPC.writeToOPC(false);
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
