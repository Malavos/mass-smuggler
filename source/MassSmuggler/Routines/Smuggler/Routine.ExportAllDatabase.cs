using Raven.Client.Document;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Abstractions.Data;
using Raven.Abstractions.Smuggler;
using Raven.Smuggler;

namespace MassSmuggler.Routines.Smuggler
{
    partial class Routine
    {
        public static void ExportAllDatabases(string url, string path)
        {
            var databases = Routines.Server.Routine.GetAllDatabaseNames(url);

            foreach (var database in databases)
            {
                Routines.Smuggler.Routine.ExportDatabase(database, url, path);
            }
        }
    }
}
