using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassSmuggler.Routines.App
{
    partial class Routine
    {
		public static void ShowHelpAndQuit()
		{
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 Export
 --export           :   [required] Export database(s) 
 --all              :   [required] Select all databases  
 --url  <value>     :   [required] Raven DB server instance URL
 --path <value>     :   [required] Ravendump files destination path

 Other
 --help             :   Show helping information
                ");
            Console.ResetColor();
            Routines.App.Routine.Quit();
        }
    }
}
