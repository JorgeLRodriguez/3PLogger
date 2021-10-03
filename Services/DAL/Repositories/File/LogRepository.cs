using Services.DAL.Contracts;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services.DAL.Repositories.File
{
    internal sealed class LogRepository : IGenericRepository<Log>
    {
        private string Config;
        #region Singleton
        private static LogRepository logRepository;

        private static object locker = new object();
        public static LogRepository GetInstance(string _Config)
        {
            if (logRepository == null)
            {
                lock (locker)
                {
                    if (logRepository == null)
                    {
                        logRepository = new LogRepository(_Config);
                    }
                }
            }
            return logRepository;
        }
        #endregion
        private LogRepository(string _Config)
        {
            Config = _Config;
        }
        public IEnumerable<Log> GetAll()
        {
            Log log = default;
            List<Log> list = new List<Log>();
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(Config, FileMode.Open)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Enum.TryParse(line.Substring(line.IndexOf("[") + 1, line.IndexOf("]") - line.IndexOf("[") - 1).Replace("Severity", "").Trim(), out Severity sev);
                        log = new Log(line.Substring(line.IndexOf("]") + 1, line.Length - line.IndexOf("]") - 1).Replace(":", "").Trim(), sev);
                        list.Add(log);
                    }
                }
                return list;
            }
            catch
            {
                throw;
            }
           
        }
        public void Insert(Log obj)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(Config, true))
                {
                    streamWriter.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") } [Severity { obj.Severity}] : { obj.Message }");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
