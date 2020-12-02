using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    public class Configuration
    {
        public string sourcePath;
        public string targetPath;
        public bool needArchive;

        public Configuration()
        {
            sourcePath = @"C:\Users\daniel\Desktop\source";
            targetPath = @"C:\Users\daniel\Desktop\target";
            needArchive = true;
        }
    }
}