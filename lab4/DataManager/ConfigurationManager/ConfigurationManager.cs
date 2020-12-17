using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager
{
    public class ConfigurationManager
    {
        private readonly IConfigurationParser configParser;
        private readonly string contents;

        public ConfigurationManager(string filePath)
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
