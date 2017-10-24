using Belatrix.SimpleLogger.SME.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belatrix.SimpleLogger.SME.BE;
using Belatrix.SimpleLogger.SME.Support;

namespace Belatrix.SimpleLogger.SME.DL
{
    public class LoggerRepositoryDB : ILoggerRepository
    {
        /// <summary>
        /// Method to log into the DataBase which implements the ILoggerRepository interface
        /// </summary>
        /// <param name="logger">Object with the log information</param>
        /// <returns>The result execution message</returns>
        public string LogMessage(Logger logger)
        {
            try
            {
                LoggerDAO.LogToDataBase(logger);
                return Constants.DBSuccessLog;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
