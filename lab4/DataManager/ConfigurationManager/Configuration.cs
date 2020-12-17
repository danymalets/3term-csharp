using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager
{
    public class Configuration
    {
        public string server { get; set; }
        public string dataBase { get; set; }
        public bool trustedConnection { get; set; }
        public string ftpServer { get; set; }

        public Configuration()
        {
            server = @"localhost\SQLEXPRESS";
            dataBase = "AdventureWorks2017";
            trustedConnection = true;
            ftpServer = @"C:\Users\daniel\Desktop\source";
        }
    }
}