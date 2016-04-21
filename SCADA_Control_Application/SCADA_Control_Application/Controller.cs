using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_Control_Application
{
    static class Controller
    {
        //Parameters
        public static double Ts { get; set; }
        public static double Kp { get; set; }
        public static double Ti { get; set; }
        public static double Sp { get; set; }

        private static double z;
        ///
        ///PI Controller With Anti Windup
        ///
        public static double PI (double lastTemp)
        {
            double u;
            double e;

            e = Sp - lastTemp;
            z = z + Ts * e;

            u = Kp * e * (Kp / Ti) * z;

            if (u > 5) { u = 5; }
            else if  (u < 0) { u = 0; }
  
            return u;
        }

    }
}
