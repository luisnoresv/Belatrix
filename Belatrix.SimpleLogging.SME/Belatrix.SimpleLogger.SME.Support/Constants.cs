using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.Support
{
    public static class Constants
    {

        public const string LOGFILENAME = "{0}LogFile{1}.txt";
        public enum LogSeverity : short { WARNING = 1, SUCCESS = 2, ERROR = 2 };
        public enum LogType : short { LogToDB = 1, LogToConsole = 2, LogToFile = 3 };
        public const string Warning = "warning";
        public const string Success = "success";
        public const string Error = "error";
        public const string DBSuccessLog = "The log message has been successfully saved on the DataBase";
        public const string FileSuccessLog = "The log message has been successfully saved on the File";
        public const string LogConsoleEvent = "Log Details: LogMessage = {0}, LogSeverity = {1}";
        public const string Domain = "LogDomain";
        public const string RootPath = @".\Plugins";
        public const string AssemblyExtension = "*.dll";
    }
}
