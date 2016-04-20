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
    public partial class frmHMI : Form
    {
        private double temp;
        private double u;
        private int count;
        
        public frmHMI()
        {
            InitializeComponent();
            InitParam();
        }

        private void InitParam()
        {
            


           

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
            label1.Text = trackBar1.Value.ToString();




            chart1.Series.Add("Series1");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            u = Controller.PI(temp);
            temp = Simulator.sim(u);
            chart1.Series["Series1"].Points.AddY(temp);
            count++;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Controller.Sp = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString();

        }
    }
}
