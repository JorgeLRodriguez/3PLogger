using Services.DAL.Repositories.File;
using Services.Domain;
using System.Collections.Generic;

namespace Services.Services.Logger
{
    internal sealed class FileLogger : ILogger
    {
        private string Config;
        #region Singleton
        private static FileLogger logger;

        private static object locker = new object();
        public static FileLogger GetInstance(string _Config)
        {
            if (logger == null)
            {
                lock (locker)
                {
                    if (logger == null)
                    {
                        logger = new FileLogger(_Config);
                    }
                }
            }
            return logger;
        }
        private FileLogger(string _Config)
        {
            Config = _Config;
        }
        #endregion
        public List<Log> GetAll()
        {
            return LogRepository.GetInstance(Config).GetAll() as List<Log>;
        }
        public void Store(Log log)
        {
            LogRepository.GetInstance(Config).Insert(log);
        }
    }
}