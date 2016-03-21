using Raven.Client.Document;
using System.Linq;

namespace MassSmuggler
{
    class Program
    {
        private static DocumentStore DocumentStore { get; set; }
        private static string DatabaseUrl { get; set; }

        static void Main(string[] args)
        {
            if (args.Contains("all"))
            {
                Routines.Database.Routine.ExportAllDatabases();
                Routines.App.Routine.Quit();
            }

            Routines.Database.Routine.ExportDatabase("MyAtuna");
        }     
    }
}
