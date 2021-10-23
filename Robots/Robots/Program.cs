using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3);
        }

        static void Main(string[] args)
        {
            Maximize();
            int maxWidth = Console.LargestWindowWidth;
            int maxHeight = Console.LargestWindowWidth;


            Console.ReadKey();
        }
    }
}
