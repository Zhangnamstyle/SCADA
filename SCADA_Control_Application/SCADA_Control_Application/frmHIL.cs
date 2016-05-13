using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCADA_Control_Application.Properties;

namespace SCADA_Control_Application
{
    public partial class frmHIL : Form
    {
        private double temp;
        private double u;

        OPC[] opcTags;
        OPC testOPC;
       
        public frmHIL()
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

            crtData.Series.Add("Series1");
            crtData.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtData.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            crtData.Series["Series1"].Color = Color.Red;
            crtData.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            crtData.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            crtData.ChartAreas[0].AxisY.LabelStyle.Format = "{0}°C";
        }

        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            bool test = testOPC.readFromOPC();
            opcHandler.checkOPC(test);
            testOPC.writeToOPC(false);
        }
        

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            tmrUpdate.Start();
            if (tmrCheck.Enabled == false)
            {
                tmrCheck.Start();
            }
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrCheck.Stop();
            tmrUpdate.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                double v = 1;
                u = IOCom.ReadControl();
                temp = Simulator.sim(u);
                if (temp < 100)
                {
                    v = cToV(temp);
                    IOCom.WriteOutput(v);
                }
                else
                {
                    Program.error = true;
                    Program.daqE = true;
                }
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

            btnStart.Enabled = true;
            btnStop.Enabled = false;

            if (Program.opcE) MessageBox.Show("Opc Server or Datalogger is not running, System has stopped", "Error");
            if (Program.daqE) MessageBox.Show("An DAQ error has occurrd, System has stopped", "Error");


        }
    
        private double cToV(double c)
        {
            return (c / 12.5) + 1;
        }

    }
         
         
}
