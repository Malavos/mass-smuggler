﻿using Raven.Client.Document;
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
        public static void ExportDatabase(string database, string url, string path)
        {
            var smugglerApi = new SmugglerDatabaseApi(new SmugglerDatabaseOptions
            {
                OperateOnTypes = ItemType.Documents | ItemType.Indexes | ItemType.Attachments | ItemType.Transformers,
                Incremental = false
            });
            var options = new SmugglerExportOptions<RavenConnectionStringOptions>
            {
                ToFile = Path.Combine(path, $"{database}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm")}.ravendump"),
                From = new RavenConnectionStringOptions
                {
                    DefaultDatabase = database,
                    Url = url
                }
            };
            smugglerApi.ExportData(options);
        }
    }
}
