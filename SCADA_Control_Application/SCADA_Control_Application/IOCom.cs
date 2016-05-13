using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments;
using NationalInstruments.DAQmx;
using SCADA_Control_Application.Properties;

namespace SCADA_Control_Application
{
    static class IOCom
    {
 
        //This code is taken from a bachelor project done by one of the group members and edited to suit this appliaction
        public static string deviceName = Settings.Default.DevName;
        public static string lastException;


       
       ///Reads the temprature from the DAQ
        public static double ReadTemp()
        {
            double analogData = 0;
            var temperatureTask = new NationalInstruments.DAQmx.Task();
            try
            {
                temperatureTask.AIChannels.CreateVoltageChannel(deviceName + "/ai0", "Temperature", AITerminalConfiguration.Rse, 1, 5, AIVoltageUnits.Volts);
                var reader = new AnalogSingleChannelReader(temperatureTask.Stream);
                analogData = reader.ReadSingleSample();
                if ((analogData < 0.5) || (analogData > 5.5)) 
                {
                    throw new Exception("Data from temperatureTask outside boundries");
                }
            }
            catch (Exception e)
            {
                analogData = 999; //999 is error code 
            }
            finally
            {
                temperatureTask.Dispose();
            }
            return analogData;
        }
        ///Reads the tcontrol volatege from the DAQ
        public static double ReadControl()
        {
            double analogData = 0;
            var temperatureTask = new NationalInstruments.DAQmx.Task();
            try
            {
                temperatureTask.AIChannels.CreateVoltageChannel(deviceName + "/ai1", "Volt", AITerminalConfiguration.Rse, 0, 5, AIVoltageUnits.Volts);
                var reader = new AnalogSingleChannelReader(temperatureTask.Stream);
                analogData = reader.ReadSingleSample();
                if ((analogData < -0.5) || (analogData > 5.5)) 
                {
                    throw new Exception("Data from temperatureTask outside boundries");
                }

            }
            catch (Exception e)
            {

                analogData = 999; //999 is an error code 
            }
            finally
            {
                temperatureTask.Dispose();
            }
            return analogData;
        }

     //Writes the outputsignal to port ao0
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
 
            }
            catch (Exception e)
            {
                lastException = Convert.ToString(e);
            }
            finally
            {
                signalTask.Dispose();
            }
        }
    }
}
