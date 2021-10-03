namespace Services.Domain
{
    public class Log
    {
        public string Message { get; set; }
        public Severity Severity { get; set; }
        public Log (string _Message, Severity _Severity)
        {
            Message = _Message;
            Severity = _Severity;
        }
    }
}
