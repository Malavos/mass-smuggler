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
		public static void Quit()
		{
            Log.Information("[smuggler] Shutting down.");
            Environment.Exit(0);
		}
    }
}
