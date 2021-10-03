using Services.Domain;
using System.Collections.Generic;

namespace Services.Services.Logger
{
    public interface ILogger
    {
        public void Store(Log log);
        public List<Log> GetAll();
    }
}
