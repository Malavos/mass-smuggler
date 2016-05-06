using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassSmuggler.Routines.App
{
    partial class Routine
    {
		public static void NotifyAndQuit(string message)
		{
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
            Log.Information("[smuggler] Shutting down after notification.");
            Routines.App.Routine.Quit();
        }
    }
}
