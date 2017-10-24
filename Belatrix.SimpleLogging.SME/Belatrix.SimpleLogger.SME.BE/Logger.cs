using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.BE
{
    [Serializable]
    public class Logger
    {
        //Besides the constructor in C# are anonymus is better to create one.
        public Logger() { }

        //Define properties instead access methods
        public string Message { get; set; }
        public short LogType { get; set; }
        public short LogSeverity { get; set; }
    }
}
