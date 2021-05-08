using System.IO;
using System.Configuration;
using System.Net.NetworkInformation;

namespace CheckPingApp
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Write data to log file
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        public static void WriteToFile(string text, string type)
        {
            switch (type)
            {
                case Constants.Log:
                    using (StreamWriter outputFile = File.AppendText(ConfigurationManager.AppSettings.Get("LogFile")))
                    {
                        outputFile.WriteLine(text);
                    }
                    break;
                case Constants.Error:
                    using (StreamWriter outputFile = File.AppendText(ConfigurationManager.AppSettings.Get("ErrorFile")))
                    {
                        outputFile.WriteLine(text);
                    }
                    break;
            }
        }

        /// <summary>
        /// Send ping to relevant host
        /// Return True/False
        /// </summary>
        /// <param name="nameOrAddress"></param>
        /// <returns></returns>
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                if (reply != null) pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException e)
            {
                WriteToFile(e.Message, Constants.Error);

            }
            finally
            {
                pinger?.Dispose();
            }

            return pingable;
        }
    }
}
