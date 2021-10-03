using Services.Domain;
using Services.Services.Logger;

namespace Services.Services
{
    public interface IApplicationServices
    {
        INewLogger NewLogger(TypeLog typeLog, string config);
        ILogger LoggerSQL { get; }
        ILogger LoggerFile { get; }
    }
}
