using Raven.Client.Document;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace MassSmuggler.Routines.Server
{
    partial class Routine
    {
        private static DocumentStore DocumentStore { get; set; }

        public static List<string> GetAllDatabaseNames(string url)
        {
            try
            {
                Log.Information($"[smuggler/routine/getalldatabasenames] Fetching database names");
                DocumentStore = new DocumentStore { Url = url };
                DocumentStore.Initialize();
                return DocumentStore
                        .DatabaseCommands
                        .GlobalAdmin
                        .GetDatabaseNames(1024, 0)
                        .ToList();
            }
            catch (Exception ex)
            {
                var details = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Log.Error($"[smuggler/routine/getalldatabasenames] Failed to fetch database names {ex.Message}; {details}");
                Routines.App.Routine.ThrowErrorAndQuit($"{ex.Message} {details}");
                return null;
            }          
        }
    }
}
