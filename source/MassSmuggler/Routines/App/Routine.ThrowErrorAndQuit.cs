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
		public static void ThrowErrorAndQuit(string message)
		{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Log.Information("[smuggler] Shutting down after error.");
            Routines.App.Routine.Quit();
        }
    }
}
