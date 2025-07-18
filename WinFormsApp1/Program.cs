using System;
using System.Windows.Forms;

namespace WinFormsApp1;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Enable visual styles and DPI awareness for better performance
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        // Pre-JIT the form to improve startup performance
        _ = new Form1();
        
        Application.Run(new Form1());
    }
}
