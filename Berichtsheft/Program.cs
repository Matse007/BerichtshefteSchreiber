using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace Berichtsheft
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.IO.File.Delete("logs/BerichtshefteSchreiberLog.txt");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/BerichtshefteSchreiberLog.txt", shared: true, retainedFileCountLimit: 1)
                .CreateLogger();
            Log.Information("Logger initialized");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
