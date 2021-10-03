using Services.Domain;

namespace Services.Services.Logger
{
    internal sealed class LoggerFactory
    {
        #region Singleton
        private static LoggerFactory logger;

        private static object locker = new object();
        public static LoggerFactory GetInstance()
        {
            if (logger == null)
            {
                lock (locker)
                {
                    if (logger == null)
                    {
                        logger = new LoggerFactory();
                    }
                }
            }
            return logger;
        }
        #endregion
        public ILogger GetTypeLog (TypeLog _typeLog, string _Config)
        {
            return _typeLog switch
            {
                TypeLog.SQL => SqlLogger.GetInstance(_Config),
                TypeLog.File => FileLogger.GetInstance(_Config),
                _ => null,
            };
        }
    }
}