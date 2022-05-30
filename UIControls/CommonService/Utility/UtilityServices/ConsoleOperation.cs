using CommonServices.Utility.IUtilityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace CommonServices.Utility.UtilityServices
{
    public class ConsoleOperation : IConsoleOperation
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public void ShowConsole()=> ShowWindow(GetConsoleWindow(), SW_SHOW);

        public void HideConsole() => ShowWindow(GetConsoleWindow(), SW_HIDE);
    }
}
