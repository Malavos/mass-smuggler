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
        public static void ExportDatabases(string url, string path, List<string> databases)
        {
            var tasks = new List<Task>();
            foreach (var database in databases)
            {
                tasks.Add(Routines.Smuggler.Routine.ExportDatabase(database, url, path));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
