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

            if (!arguments.Any()) Routines.App.Routine.ShowHelpAndQuit();

            // If arguments does not contain existing function show help and quit
            // When creating new functions add them to this if statement
            if(!arguments.Contains("--export")
                && !arguments.Contains("--help")) Routines.App.Routine.ShowHelpAndQuit();

            #region export

            if (arguments.Contains("--export"))
            {
                #region --all

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
                            Routines.App.Routine.ThrowError("Please provide a value to database server url argument; --url <value>");
                            Routines.App.Routine.ShowHelpAndQuit();
                        }
                    }
                    else
                    {
                        Routines.App.Routine.ThrowError("Please provide a database server url argument; --url");
                        Routines.App.Routine.ShowHelpAndQuit();
                    }

                    if (arguments.Contains("--path"))
                    {
                        try
                        {
                            path = arguments[arguments.FindIndex(a => a == "--path") + 1];

                            if (!Directory.Exists(path)) Routines.App.Routine.ThrowError($"The path '{path}' does not exist.");
                        }
                        catch (Exception)
                        {
                            Routines.App.Routine.ThrowError("Please provide a value to the export path argument; --path <value>");
                            Routines.App.Routine.ShowHelpAndQuit();
                        }
                    }
                    else
                    {
                        Routines.App.Routine.ThrowError("Please provide a export path argument; --path");
                        Routines.App.Routine.ShowHelpAndQuit();
                    }

                    var databases = Routines.Server.Routine.GetAllDatabaseNames(url);
                    Routines.Smuggler.Routine.ExportDatabases(url, path, databases);
                }
                else
                {
                    Routines.App.Routine.ShowHelpAndQuit();
                }

                #endregion
            }

            #endregion

            #region help

            if(arguments.Contains("--help"))
            {
                Routines.App.Routine.ShowHelpAndQuit();
            }

            #endregion
        }
    }
}

