namespace Services.Services.Logger
{
    public interface INewLogger
    {
        string[] ReadAll();
        void Write(string log);
    }
}
