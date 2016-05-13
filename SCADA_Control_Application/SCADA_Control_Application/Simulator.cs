using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SCADA_Control_Application
{
    static class Simulator
    {
        //Parameters
        public static double envTemp;
        public static double Kh;
        public static double ThetaT;
        public static double Tdly;
        public static double Ts;
        public static int N;

        public static double Tout_k;
        private static double Tout_k_1;
        /// The simulator used with HIL And PC Control System. Simulating the airheater using input voltage u. Tout_k is temperature output from airheater.
        public static double sim(double u)
        {
            double dTout_k;

            Thread.Sleep(Convert.ToInt16(Tdly*1000));

            dTout_k = (1 / ThetaT) * (-Tout_k + envTemp + Kh * u);
            Tout_k_1 = Ts * dTout_k + Tout_k;
            Tout_k = Tout_k_1;

            return Tout_k;
        }
        
 

      

    }
}
