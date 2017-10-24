using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.DL.DataProviders
{
    public class DBLoggerConnection
    {
        public string SqlConnectionString { get; set; }
        public DBLoggerConnection()
        {
            SqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        }
        public SqlConnection GetInstance()
        {
            var sqlCn = new SqlConnection(SqlConnectionString);
            return sqlCn;
        }
    }
}
