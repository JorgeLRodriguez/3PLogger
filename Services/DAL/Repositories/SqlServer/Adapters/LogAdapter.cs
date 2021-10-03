using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Repositories.SqlServer.Adapters
{
    internal class LogAdapter
    {
        #region Singleton
        private static LogAdapter Adapter;

        private static object locker = new object();
        public static LogAdapter GetInstance()
        {
            if (Adapter == null)
            {
                lock (locker)
                {
                    if (Adapter == null)
                    {
                        Adapter = new LogAdapter();
                    }
                }
            }
            return Adapter;
        }
        #endregion
        private LogAdapter(){}
        public Log Adapt(object[] values)
        {
            return new Log(values[(int)Columns.Message].ToString(), (Severity)int.Parse(values[(int)Columns.Severity].ToString())){};
        }
        private enum Columns
        {
            Severity,
            Message
        }
    }
}
