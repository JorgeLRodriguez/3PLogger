using Services.Domain;
using Services.Services.Mail;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services.Logger
{
    internal sealed class Logger : ILogger , INewLogger
    {
        private TypeLog TypeLog;
        private string Config;
        private readonly IMail mail;
        public Logger (TypeLog _TypeLog, string _Config)
        {
            TypeLog = _TypeLog;
            Config = _Config;
            mail = Mail.Mail.GetInstance();
        }
        public string[] ReadAll()
        {
            string[] Msgs = GetAll().Select(x => x.Message).ToArray();
            return Msgs;
        }
        public void Write(string log)
        {
            Store(new Log(log, Severity.Informative));
        }
        public void Store(Log log)
        {
            if (log.Message.Contains("CriticalError"))       
                mail.SendMail("soporteNivel1@email.com", log.Message);
            
            if (log.Message.Contains("FatalError"))           
                mail.SendMail("soporteNivel1@email.com;soporteNivel2@email.com", log.Message);
         
            LoggerFactory.GetInstance().GetTypeLog(TypeLog, Config).Store(log);
        }
        public List<Log> GetAll()
        {
            return LoggerFactory.GetInstance().GetTypeLog(TypeLog, Config).GetAll();
        }

    }
}
