using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace CheckPingApp
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main(string[] args)
        {
            IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
            CheckPingApp CheckPingApp = new CheckPingApp();
            ShowWindow(h, 0);
            CheckPingApp.CheckP();
        }
    }
}
