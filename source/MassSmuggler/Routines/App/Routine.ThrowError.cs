using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassSmuggler.Routines.App
{
    partial class Routine
    {
		public static void ThrowError(string message)
		{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Routines.App.Routine.Quit();
        }
    }
}
