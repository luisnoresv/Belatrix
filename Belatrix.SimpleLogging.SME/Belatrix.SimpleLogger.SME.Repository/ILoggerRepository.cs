using Belatrix.SimpleLogger.SME.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.Repository
{
    public interface ILoggerRepository
    {
        /// <summary>
        /// Method to log the message in some enviroment
        /// </summary>
        /// <param name="logger">Log info</param>
        /// <returns>A message which indicates the result operation</returns>
        string LogMessage(Logger logger);
    }
}
