using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments;
using NationalInstruments.DAQmx;

namespace SCADA_Control_Application
{
    static class IOCom
    {
        public static string deviceName = "dev4";
        public static string lastException;
        //Variables used to check if the user has been notified already when there's an error and to make sure the error values aren't used.
        public static Boolean errorReported = false;
        public static Boolean signalOutError = false;

       
        /// <summary>
        /// Retrieves the signal from the ai0 input on the IO-unit. Returns 999 upon error. Exception is available in IOCom.lastException.
        /// </summary>
        /// <returns>Signal in volts</returns>
        public static double ReadInput()
        {
            double analogData = 0;
            var temperatureTask = new NationalInstruments.DAQmx.Task();
            try
            {
                temperatureTask.AIChannels.CreateVoltageChannel(deviceName + "/ai0", "Temperature", AITerminalConfiguration.Rse, 1, 5, AIVoltageUnits.Volts);
                var reader = new AnalogSingleChannelReader(temperatureTask.Stream);
                analogData = reader.ReadSingleSample();
                if ((analogData < 0.7) || (analogData > 5.3)) //Confirms that the signal is within the boundries of 1-5V, with a 0.3V margin of error. 
                {
                    throw new Exception("Data from temperatureTask outside boundries");
                }
                errorReported = false;
            }
            catch (Exception e)
            {
                lastException = Convert.ToString(e);
                analogData = 999; //999 vil være en feilkode, exceptionen må hentes ut fra lastException stringen. 
            }
            finally
            {
                temperatureTask.Dispose();
            }
            return analogData;
        }

        /// <summary>
        /// Sends a signal from the ao0 output on the IO-unit. Exception is available in IOCom.lastException.
        /// </summary>
        public static void WriteOutput(double signal)
        {
            double analogData;
            var signalTask = new NationalInstruments.DAQmx.Task();
            try
            {
                analogData = signal;
                signalTask.AOChannels.CreateVoltageChannel(deviceName + "/ao0", "Signal", 0, 5, AOVoltageUnits.Volts);
                var writer = new AnalogSingleChannelWriter(signalTask.Stream);
                writer.WriteSingleSample(true, analogData);
                errorReported = false;
                signalOutError = false;
            }
            catch (Exception e)
            {
                lastException = Convert.ToString(e);
                signalOutError = true;
            }
            finally
            {
                signalTask.Dispose();
            }
        }
    }
}
