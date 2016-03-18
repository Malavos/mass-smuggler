using Raven.Client.Document;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securancy.RavenDbTool.Routines.Database
{
    partial class Routine
    {
        public static List<string> GetAllDatabaseNames()
        {
            return AppSettings.DocumentStore
                    .DatabaseCommands
                    .GlobalAdmin
                    .GetDatabaseNames(1024, 0)
                    .ToList();
        }
    }
}
