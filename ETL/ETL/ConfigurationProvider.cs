using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ETL
{
    public class ConfigurationProvider
    {
        private readonly IConfigurationParser configParser;
        private readonly string contents;

        public ConfigurationProvider(string filePath)
        {
            contents = File.ReadAllText(filePath);
            string ext = Path.GetExtension(filePath);
            if (ext == ".json")
            {
                configParser = new JSONParser();
            }
            else if (ext == ".xml")
            {
                configParser = new XMLParser();
            }
            else
            {
                throw new Exception("Invalid extension");
            }
        }

        public Configuration GetConfiguration()
        {
            return configParser.Parse<Configuration>(contents);
        }
    }
}
