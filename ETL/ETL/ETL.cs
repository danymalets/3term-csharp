using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    public partial class ETL : ServiceBase
    {
        Watcher watcher;
        static string path1 = @"C:\Users\daniel\Desktop\opt.json";
        static string path2 = @"C:\Users\daniel\Desktop\opt.xml";

        public ETL()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Configuration config;
            try
            {
                ConfigurationProvider provider = new ConfigurationProvider(path1);
                config = provider.GetConfiguration();
            }
            catch
            {
                config = new Configuration();
            }
            watcher = new Watcher(config.sourcePath, config.targetPath, config.needArchive);
            watcher.Start();
        }

        protected override void OnStop()
        {
            watcher.Stop();
        }
    }
}
