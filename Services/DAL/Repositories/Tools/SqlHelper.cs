using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Repositories.Tools
{
    internal static class SqlHelper
    {
        public static Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, string conString, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static SqlDataReader ExecuteReader(String commandText,
            CommandType commandType, string conString, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(conString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }
    }
}
