﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    public partial class ETL : ServiceBase
    {
        Watcher watcher;
        string source = @"C:\Users\daniel\Desktop\source";
        string target = @"C:\Users\daniel\Desktop\target";

        public ETL()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            watcher = new Watcher(source, target);
            watcher.Start();
        }

        protected override void OnStop()
        {
            watcher.Stop();
        }
    }
}
