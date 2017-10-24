using Belatrix.SimpleLogger.SME.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belatrix.SimpleLogger.SME.BE;
using Belatrix.SimpleLogger.SME.Support;

namespace Belatrix.SimpleLogger.SME.FileManager
{
    public class LoggerRepositoryFM : ILoggerRepository
    {
        /// <summary>
        ///  Method to log on some File which implements the ILoggerRepository interface
        /// </summary>
        /// <param name="logger">Object with the log information</param>
        /// <returns>The result execution message</returns>
        public string LogMessage(Logger logger)
        {
            try
            {
                LoggerFileManager.LogToFile(logger);
                return Constants.FileSuccessLog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
