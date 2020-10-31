using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    static class Archive
    {
        public static void Compress(string source, string target)
        {
            using (FileStream ss = new FileStream(source, FileMode.Open))
            {
                using (FileStream ts = File.Create(target))
                {
                    using (GZipStream zs = new GZipStream(ts, CompressionMode.Compress))
                    {
                        ss.CopyTo(zs);
                    }
                }

            }
        }

        public static void Decompress(string source, string target)
        {
            using (FileStream ss = new FileStream(source, FileMode.OpenOrCreate))
            {
                using (FileStream ts = File.Create(target))
                {
                    using (GZipStream zs = new GZipStream(ss, CompressionMode.Decompress))
                    {
                        zs.CopyTo(ts);
                    }
                }
            }
        }
    }
}
