using System;

namespace Services.Services.Mail
{
    internal sealed class Mail : IMail
    {
        #region Singleton
        private static Mail mail;

        private static object locker = new object();
        public static Mail GetInstance()
        {
            if (mail == null)
            {
                lock (locker)
                {
                    if (mail == null)
                    {
                        mail = new Mail();
                    }
                }
            }
            return mail;
        }
        #endregion
        public void SendMail(string recipient, string message)
        {
            Console.WriteLine("Mail sent to {0}", recipient);
        }
    }
}
