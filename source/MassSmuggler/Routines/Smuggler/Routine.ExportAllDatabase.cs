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

namespace MassSmuggler.Routines.Database
{
    partial class Routine
    {
        public static void ExportAllDatabases()
        {
            var databases = Routine.GetAllDatabaseNames();

            foreach (var database in databases)
            {
                Routine.ExportDatabase(database);
            }
        }
    }
}
