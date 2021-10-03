using Services.Domain;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Test
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        AppSettings();
    //        var AppServices = new ApplicationServices();
    //        var NewLoggerSQL = AppServices.NewLogger(TypeLog.SQL, ApplicationSettings.GetInstance().Cnn);
    //        var NewLoggerFile = AppServices.NewLogger(TypeLog.File, ApplicationSettings.GetInstance().LogPath);
    //        var SQLLogger = AppServices.LoggerSQL;
    //        var FileLogger = AppServices.LoggerFile;

    //        SQLLogger.Store(new Log("SQL Test", Severity.Warning));
    //        var listSQL = SQLLogger.GetAll();

    //        FileLogger.Store(new Log("File Test", Severity.Warning));
    //        var listFile = FileLogger.GetAll();

    //        NewLoggerSQL.Write("New SQL Test");
    //        string[] arrSQL = NewLoggerSQL.ReadAll();

    //        NewLoggerFile.Write("New File Test");
    //        string[] arrFile = NewLoggerFile.ReadAll();

    //        NewLoggerFile.Write("CriticalError");
    //        NewLoggerSQL.Write("CriticalError");

    //        NewLoggerFile.Write("FatalError");
    //        NewLoggerSQL.Write("FatalError");


    //        IEnumerable<int> numbers = Enumerable.Range(0, 10);
    //        Console.WriteLine(numbers.(a => a == 1));

    //    }
    //    private static void AppSettings()
    //    {
    //        ApplicationSettings.GetInstance().Cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
    //        ApplicationSettings.GetInstance().LogPath = ConfigurationManager.AppSettings["LogPath"];
    //    }
    //}

    class A
    {
        public virtual string Method()
        {
            return "A";
        }
    }

    class B : A
    {
        public new string Method()
        {
            return "B";
        }
    }

    class C : A
    {
        public override string Method()
        {
            return "C";
        }
    }


    public class Program
    {
        public static void Main()
        {
            A obj = new B();
            A obj2 = new C();
            Console.WriteLine(obj.Method());
            Console.WriteLine(obj2.Method());
        }
    }
}