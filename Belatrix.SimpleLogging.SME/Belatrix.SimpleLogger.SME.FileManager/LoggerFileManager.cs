using Belatrix.SimpleLogger.SME.BE;
using Belatrix.SimpleLogger.SME.Support;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.FileManager
{
    public static class LoggerFileManager
    {
        /// <summary>
        /// Logging the message on a File
        /// </summary>
        /// <param name="logger">Object with the log information</param>
        public static void LogToFile(Logger logger)
        {
            var dateWithFormat = DateTime.Now.ToString("ddMMyyyy");
            string fileText;
            var severity = Helpers.GetSeverity(logger.LogSeverity);

            var filePath = string.Format(Constants.LOGFILENAME, ConfigurationManager.AppSettings["LogFileDirectory"].ToString(), dateWithFormat);
            fileText = "[Date]: " + DateTime.Now.ToString() + " [Log Message]: " + logger.Message + " [Log Severity]: " + severity;
            if (File.Exists(filePath))
            {
                try
                {
                    File.AppendAllText(filePath, fileText + Environment.NewLine);
                }
                catch (FieldAccessException ex)
                {
                    throw ex;
                }

            }
            else
            {
                try
                {
                    File.WriteAllText(filePath, fileText);
                }
                catch (FieldAccessException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
