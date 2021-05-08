using System;
using System.Configuration;
using System.Threading;
using System.Windows;

namespace CheckPingApp
{
    class CheckPingApp
    {
        public  void CheckP()
        {
            var ip = ConfigurationManager.AppSettings.Get("IP");
            Boolean flag = false;
            while (true)
            {
               ExtensionMethods.WriteToFile($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.ff} - התחלת בדיקה", Constants.Log);
                for (int i = 0; i < 4; i++)
               {
                    flag = ExtensionMethods.PingHost(ip);
                   if (flag == true)
                    {
                        break;
                    }
                   Thread.Sleep(2000);
                }
               
                if (!flag)
                {
                    ExtensionMethods.WriteToFile($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.ff} - שלט אלקטרוני - בעיית חיבור לשלט", Constants.Error);
                    MessageBox.Show(Constants.ProblemMessage, Constants.Station);
                }

                ExtensionMethods.WriteToFile($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.ff} - סיום בדיקה",Constants.Log);
                Thread.Sleep(10000);
            }
        }
    }
}
