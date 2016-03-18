using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securancy.RavenDbTool
{
    public static class AppSettings
    {
        public static string DataBaseServerUrl { get; set; }
        public static string ExportPath { get; set; }
        public static DocumentStore DocumentStore { get; set; }

        static AppSettings()
        {
            Initialize();
            InitializeDocumentStore();
        }

        private static void Initialize()
        {
            // Fetch
            var url = ConfigurationManager.AppSettings["DataBaseServerUrl"];
            var exportPath = ConfigurationManager.AppSettings["ExportPath"];

            // Validate settings
            if (string.IsNullOrEmpty(url)) throw new Exception("[AppSettings/Initialize] Failed to locate DataBaseServerUrl from app settings");
            if (string.IsNullOrEmpty(exportPath)) throw new Exception("[AppSettings/Initialize] Failed to locate ExportPath from app settings");

            // Other validations
            if(!Directory.Exists(exportPath)) throw new Exception("[AppSettings/Initialize] Export path does not exist");

            // Set
            DataBaseServerUrl = url;
            ExportPath = exportPath;
        }

        private static void InitializeDocumentStore()
        {
            DocumentStore = new DocumentStore
            {
                Url = DataBaseServerUrl
            };
            DocumentStore.Initialize();
        }
    }
}
