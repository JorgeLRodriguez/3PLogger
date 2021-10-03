using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer.Adapters;
using Services.DAL.Repositories.Tools;
using Services.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Services.DAL.Repositories.SqlServer
{
    internal class LogRepository : IGenericRepository<Log>
    {
        private string Config;
        #region Singleton
        private static LogRepository logRepository;

        private static object locker = new object();
        public static LogRepository GetInstance(string _Config)
        {
            if (logRepository == null)
            {
                lock (locker)
                {
                    if (logRepository == null)
                    {
                        logRepository = new LogRepository(_Config);
                    }
                }
            }
            return logRepository;
        }
        #endregion
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Log]([Severity],[Message])VALUES(@Severity,@Message)";
        }
        private string SelectAllStatement
        {
            get => "SELECT [Severity],[Message]FROM [dbo].[Log]";
        }
        #endregion
        private LogRepository(string _Config)
        {
            Config = _Config;
        }
        public IEnumerable<Log> GetAll()
        {
            List<Log> list = new List<Log>();
            try
            {
                using (var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text, Config))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        list.Add(LogAdapter.GetInstance().Adapt(values));
                    }
                }
            }
            catch
            {
                throw;
            }
            return list;
        }
        public void Insert(Log obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, Config, new SqlParameter[]
                { new SqlParameter("@Severity", (int)obj.Severity), new SqlParameter("@Message",obj.Message) });
            }
            catch
            {
                throw;
            }
        }
    }
}