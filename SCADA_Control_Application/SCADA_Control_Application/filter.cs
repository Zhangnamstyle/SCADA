using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCADA_Control_Application.Properties;

namespace SCADA_Control_Application
{
    static class filter
    {
        //This filter is not used since the sample time is set so long. Can be implemented if a smaller sample time is used.
        public static double temp = 0;
        public static double temp_k = 0;
        public static double temp_k_1 = 0;
        public static double Tf= 0.5;
        public static double Ts = Settings.Default.Ts;
        //Low pass filter with a filter constant Tf
        public static double lpFilter(double RawT)
        {
            temp = RawT;
            temp_k_1 = (Ts / Tf) * (temp - temp_k) + temp_k;
            temp_k = temp_k_1;
            return temp_k;
        }
    }

}
