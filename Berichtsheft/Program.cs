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
        /// The main start for the entire program. We are deleting the logfile for a previous session, if one exists.
        /// Afterwards a new logger and logfile is created and we are loading the Form.
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
