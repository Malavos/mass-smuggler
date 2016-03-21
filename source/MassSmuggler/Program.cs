using Raven.Client.Document;
using System;
using System.IO;
using System.Linq;

namespace MassSmuggler
{
    class Program
    {
        private static DocumentStore DocumentStore { get; set; }

        static void Main(string[] args)
        {
            var arguments = args.ToList();

            if (arguments.Contains("--all"))
            {
                var url = string.Empty;
                var path = string.Empty;

                if (arguments.Contains("--url"))
                {
                    try
                    {
                        url = arguments[arguments.FindIndex(a => a == "--url") + 1];
                    }
                    catch (Exception)
                    {
                        Routines.App.Routine.ThrowErrorAndQuit("Please provide a value to database server url argument; --url <value>");
                    }
                }
                else
                {
                    Routines.App.Routine.ThrowErrorAndQuit("Please provide a database server url argument; --url");
                }

                if (arguments.Contains("--path"))
                {
                    try
                    {
                        path = arguments[arguments.FindIndex(a => a == "--path") + 1];

                        if (!Directory.Exists(path)) Routines.App.Routine.ThrowErrorAndQuit($"The path '{path}' does not exist.");
                    }
                    catch (Exception)
                    {
                        Routines.App.Routine.ThrowErrorAndQuit("Please provide a value to the export path argument; --path <value>");
                    }
                }
                else
                {
                    Routines.App.Routine.ThrowErrorAndQuit("Please provide a export path argument; --path");
                }

                Routines.Smuggler.Routine.ExportAllDatabases(url, path);
            }

            Console.ReadKey();
        }
    }
}

