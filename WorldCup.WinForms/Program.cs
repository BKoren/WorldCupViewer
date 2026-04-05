using System;
using System.Windows.Forms;

namespace WorldCup.WinForms
{
    internal static class Program
    {
        [STAThread]		
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormManager());
        }
    }
}
