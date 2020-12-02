using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    class Watcher
    {
        FileSystemWatcher watcher;
        Logger logger;
        string source;
        string target;
        bool needArchive;

        public Watcher(string source, string target, bool needArchive)
        {
            this.source = source;
            this.target = target;
            this.needArchive = needArchive;
            Directory.CreateDirectory(source);
            Directory.CreateDirectory(target);

            string logerPath = Path.Combine(target, "log");
            logger = new Logger(logerPath);

            watcher = new FileSystemWatcher(source);
            watcher.Filter = "*.txt";
            watcher.Created += OnCreated;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                DateTime dt = fileInfo.LastWriteTime;

                byte[] key, iv;
                (key, iv) = Encryptor.CreateKeyAndIV();

                byte[] contents = File.ReadAllBytes(path);
                contents = Encryptor.Encrypt(contents, key, iv);
                File.WriteAllBytes(path, contents);

                string name = Path.GetFileNameWithoutExtension(path);
                string ext = Path.GetExtension(path);

                string gzPath = Path.Combine(target, name + ".gz");
                string newPath = Path.Combine(target, name + ext);

                if (needArchive) Archive.Compress(path, gzPath);
                if (needArchive) Archive.Decompress(gzPath, newPath);
                if (!needArchive) File.Copy(path, newPath);

                contents = File.ReadAllBytes(newPath);
                contents = Encryptor.Decrypt(contents, key, iv);
                File.WriteAllBytes(newPath, contents);

                File.Delete(path);
                if (needArchive) File.Delete(gzPath);

                string year = dt.ToString("yyyy");
                string month = dt.ToString("MM");
                string day = dt.ToString("dd");
                string newArchiveDir = Path.Combine(target, $@"archive\{year}\{month}\{day}");
                string newArchiveName = dt.ToString(@"yyyy_MM_dd_HH_mm_ss") + ext;
                string newArchivePath = Path.Combine(newArchiveDir, newArchiveName);

                Directory.CreateDirectory(newArchiveDir);
                File.Copy(newPath, newArchivePath);

                logger.Log($"File {path} moved successfully");
            }
            catch
            {
                try
                {
                    logger.Log($"Error moving {path} file");
                }
                catch
                {

                }
            }
        }
    }
}
