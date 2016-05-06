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
using System.IO;

namespace MassSmuggler.Routines.Smuggler
{
    partial class Routine
    {
        public static async Task ExportDatabase(string database, string url, string path)
        {
            // Create database back up folder if it does not exists
            if (!Directory.Exists(Path.Combine(path, database)))
                Directory.CreateDirectory(Path.Combine(path, database));

            var smugglerApi = new SmugglerDatabaseApi(new SmugglerDatabaseOptions
            {
                OperateOnTypes = ItemType.Documents | ItemType.Indexes | ItemType.Attachments | ItemType.Transformers,
                Incremental = false
            });
            var options = new SmugglerExportOptions<RavenConnectionStringOptions>
            {
                ToFile = Path.Combine($"{path}/{database}", $"{database}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm")}.ravendump"),

                From = new RavenConnectionStringOptions
                {
                    DefaultDatabase = database,
                    Url = url
                }
            };
            await smugglerApi.ExportData(options);
        }
    }
}
