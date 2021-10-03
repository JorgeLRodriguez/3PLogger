namespace Services.Services
{
    public class ApplicationSettings
    {
        #region Singleton
        private static ApplicationSettings app;

        private static object locker = new object();
        public static ApplicationSettings GetInstance()
        {
            if (app == null)
            {
                lock (locker)
                {
                    if (app == null)
                    {
                        app = new ApplicationSettings();
                    }
                }
            }
            return app;
        }
        #endregion
        public string Cnn { get; set; }
        public string LogPath { get; set; }
    }
}
