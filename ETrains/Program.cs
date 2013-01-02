using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ETrains
{
    //Windows API need to use in Mutex program
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
    static class Program
    {
        static readonly Mutex Mutex = new Mutex(true, "{23A90C21-7121-4C55-AEA4-1CFF7A118D16}");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                CheckConnection();
            }
            else
            {

                //If the application is started, show the message to warning and...
                MessageBox.Show("eTrain đã được khởi động. Bạn hãy kiểm tra lại cửa sổ đang mở!", "ETrains",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //Then post a message to show the opened windows
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }

        private static void CheckConnection()
        {
            if (ConfigurationManager.ConnectionStrings["dbTrainEntities"] == null)
            {
                Application.Run(new frmConfigSQL());
            }
            if (ConfigurationManager.ConnectionStrings["dbTrainEntities"] == null)
            {
                Application.Exit();
                return;
            }
            Application.Run(new frmLogin());
        }
    }
}
