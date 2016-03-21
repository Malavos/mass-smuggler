using Raven.Client.Document;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassSmuggler.Routines.Server
{
    partial class Routine
    {
        private static DocumentStore DocumentStore { get; set; }

        public static List<string> GetAllDatabaseNames(string url)
        {
            DocumentStore = new DocumentStore { Url = url };
            DocumentStore.Initialize();
            return DocumentStore
                    .DatabaseCommands
                    .GlobalAdmin
                    .GetDatabaseNames(1024, 0)
                    .ToList();
        }
    }
}
