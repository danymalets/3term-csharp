using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    class Logger
    {
        string loggerPath;

        public Logger(string path)
        {
            Directory.CreateDirectory(path);
            loggerPath = Path.Combine(path, "log.txt");
            if (!File.Exists(loggerPath))
            {
                File.Create(loggerPath);
            }
        }

        public void Log(string mess)
        {
            string dt = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");
            using (StreamWriter sw = new StreamWriter(loggerPath, true))
            {
                sw.WriteLine($"{dt} - {mess}");
            }
        }
    }
}
