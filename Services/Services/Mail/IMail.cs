namespace Services.Services.Mail
{
    internal interface IMail
    {
        void SendMail(string recipient, string message);
    }
}
