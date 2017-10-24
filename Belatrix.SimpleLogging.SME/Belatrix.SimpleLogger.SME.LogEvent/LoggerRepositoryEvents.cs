using Belatrix.SimpleLogger.SME.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belatrix.SimpleLogger.SME.BE;
using Belatrix.SimpleLogger.SME.Support;

namespace Belatrix.SimpleLogger.SME.LogEvent
{
    public class LoggerRepositoryEvents : ILoggerRepository
    {
        /// <summary>
        /// Method to log on the console which implements the ILoggerRepository interface
        /// </summary>
        /// <param name="logger">Object with the log information</param>
        /// <returns>The result execution message</returns>
        public string LogMessage(Logger logger)
        {
            var severity = Helpers.GetSeverity(logger.LogSeverity);
            return string.Format(Constants.LogConsoleEvent, logger.Message, severity);
        }
    }
}
