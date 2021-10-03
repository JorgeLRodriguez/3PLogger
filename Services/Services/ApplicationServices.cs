using Services.Domain;
using Services.Services.Logger;

namespace Services.Services
{
    public class ApplicationServices : IApplicationServices
    {
        public ILogger LoggerSQL
        {
            get { return SqlLogger.GetInstance(ApplicationSettings.GetInstance().Cnn); }
        }
        public ILogger LoggerFile
        {
            get { return FileLogger.GetInstance(ApplicationSettings.GetInstance().LogPath); }
        }
        public INewLogger NewLogger(TypeLog typeLog, string config)
        {
             return new Logger.Logger(typeLog,config);
        }
    }
}