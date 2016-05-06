using Raven.Client.Document;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MassSmuggler
{
    class Program
    {
        private static DocumentStore DocumentStore { get; set; }

        static void Main(string[] args)
        {
            try
            {
                RegisterLogger();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to register logger {ex.Message}");
            }

            var arguments = args.ToList();

            if (!arguments.Any()) Routines.App.Routine.ShowHelpAndQuit();

            Log.Information("[smuggler] Booting.");

            // If arguments does not contain existing function show help and quit
            // When creating new functions add them to this if statement
            if (!arguments.Contains("--export")
                && !arguments.Contains("--help"))
            {
                Log.Information("[smuggler] No arguments found. Exiting");
                Routines.App.Routine.ShowHelpAndQuit();
            }

            #region export

            if (arguments.Contains("--export"))
            {
                #region --all

                Log.Information("[smuggler/export] Starting with export...");

                if (arguments.Contains("--all"))
                {
                    var url = string.Empty;
                    var path = string.Empty;

                    if (arguments.Contains("--url"))
                    {
                        try
                        {
                            url = arguments[arguments.FindIndex(a => a == "--url") + 1];
                            Log.Information($"[smuggler/export/alldatabases] Found database server url: {url}");
                        }
                        catch (Exception)
                        {
                            Log.Error($"[smuggler/export/alldatabases] Failed to find database url");
                            Routines.App.Routine.ThrowError("Please provide a value to database server url argument; --url <value>");
                            Routines.App.Routine.ShowHelpAndQuit();
                        }
                    }
                    else
                    {
                        Log.Error($"[smuggler/export/alldatabases] Failed to find argument for database url");
                        Routines.App.Routine.ThrowError("Please provide a database server url argument; --url");
                        Routines.App.Routine.ShowHelpAndQuit();
                    }

                    if (arguments.Contains("--path"))
                    {
                        try
                        {
                            path = arguments[arguments.FindIndex(a => a == "--path") + 1];
                            Log.Information($"[smuggler/export/alldatabases] Found back up path: {path}");

                            if (!Directory.Exists(path))
                            {
                                Log.Error($"[smuggler/export/alldatabases] Provided backup directory does not exists {path}");
                                Routines.App.Routine.ThrowError($"The path '{path}' does not exist.");
                            }
                        }
                        catch (Exception)
                        {
                            Log.Error($"[smuggler/export/alldatabases] Failed to find backup path");
                            Routines.App.Routine.ThrowError("Please provide a value to the export path argument; --path <value>");
                            Routines.App.Routine.ShowHelpAndQuit();
                        }
                    }
                    else
                    {
                        Log.Error($"[smuggler/export/alldatabases] Failed to backup path argument");
                        Routines.App.Routine.ThrowError("Please provide a export path argument; --path");
                        Routines.App.Routine.ShowHelpAndQuit();
                    }

                    Log.Error($"[smuggler/export/alldatabases] Starting backup of all database");
                    var databases = Routines.Server.Routine.GetAllDatabaseNames(url);
                    Routines.Smuggler.Routine.ExportDatabases(url, path, databases);
                    Log.Information($"[smuggler/export/exportdatabases] Database backups are complete..");
                }
                else
                {
                    Routines.App.Routine.ShowHelpAndQuit();
                }

                #endregion
            }

            #endregion

            #region help

            if (arguments.Contains("--help"))
            {
                Log.Information("[smuggler/help] Showing help information");
                Routines.App.Routine.ShowHelpAndQuit();
            }

            #endregion

            Log.Information("[smuggler] Shutting down.");
        }

        static void RegisterLogger()
        {
            var logDirectory = Path.Combine(Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)), "logs");

            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            try
            {
                var log = new LoggerConfiguration()
               .WriteTo.RollingFile(Path.Combine(logDirectory,"smuggler_log_{Date}.txt"))
               .CreateLogger();
                Log.Logger = log;
            }
            catch (Exception up)
            {
                throw up;
            }
        }
    }
}

