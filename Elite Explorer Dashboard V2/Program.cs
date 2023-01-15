using System.Diagnostics;

namespace Elite_Explorer_Dashboard_V2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Debug.WriteLine("Initialize");
            Application.Run(new EliteExplorer());
        }
    }
}