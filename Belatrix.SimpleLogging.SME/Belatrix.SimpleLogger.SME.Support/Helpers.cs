using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.Support
{
    public static class Helpers
    {
        public static string GetSeverity(short logSeverityCode)
        {
            string severity = string.Empty;
            switch (logSeverityCode)
            {
                case 1:
                    severity = Constants.Warning;
                    break;
                case 2:
                    severity = Constants.Success;
                    break;
                case 3:
                    severity = Constants.Error;
                    break;
            }
            return severity;
        }
    }
}
