using Services.DAL.Repositories.SqlServer;
using Services.Domain;
using System.Collections.Generic;

namespace Services.Services.Logger
{
    internal sealed class SqlLogger : ILogger
    {
        private string Config;
        #region Singleton
        private static SqlLogger logger;

        private static object locker = new object();
        public static SqlLogger GetInstance(string _Config)
        {
            if (logger == null)
            {
                lock (locker)
                {
                    if (logger == null)
                    {
                        logger = new SqlLogger(_Config);
                    }
                }
            }
            return logger;
        }
        private SqlLogger(string _Config)
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
