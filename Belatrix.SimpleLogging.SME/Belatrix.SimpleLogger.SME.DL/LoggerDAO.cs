using Belatrix.SimpleLogger.SME.BE;
using Belatrix.SimpleLogger.SME.DL.DataProviders;
using Belatrix.SimpleLogger.SME.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.DL
{
    public static class LoggerDAO
    {
        /// <summary>
        /// Log the message into the DataBase
        /// </summary>
        /// <param name="logger">Object with the log information</param>
        public static void LogToDataBase(Logger logger)
        {
            SqlCommand cmd;
            //Use try and catch code block to have a better control of the exceptions
            try
            {
                //A best practice is use the using statement if you want to use a sqlConnection, the using statement manage the connection lifetime,
                //you don´t have to dispose the connection
                using (SqlConnection sqlCn = new DBLoggerConnection().GetInstance())
                {
                    sqlCn.Open();
                    var severity = Helpers.GetSeverity(logger.LogSeverity);

                    cmd = new SqlCommand()
                    {
                        Connection = sqlCn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "AddNewLog"
                    };
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@logMessage",
                        SqlDbType = SqlDbType.VarChar,
                        Value = logger.Message
                    });
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@logSeverity",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 10,
                        Value = severity
                    });
                    cmd.ExecuteNonQuery();
                }
            }
            catch (DataException ex)
            {
                throw ex;
            }
        }
    }
}
