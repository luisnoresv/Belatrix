using Belatrix.SimpleLogger.SME.BE;
using Belatrix.SimpleLogger.SME.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.App.Infraestructure
{
    class LoadMyAssembly : MarshalByRefObject
    {
        private Assembly assembly;
        private string resultMsgOperation;

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void LoadAssembly(string path)
        {
            assembly = Assembly.Load(AssemblyName.GetAssemblyName(path)); ;
        }

        public string ExecuteStaticLoggerMethod(Logger logger)
        {
            resultMsgOperation = string.Empty;
            try
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(ILoggerRepository)))
                    {
                        var context = Activator.CreateInstance(type) as ILoggerRepository;
                        resultMsgOperation = context.LogMessage(logger);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultMsgOperation;
            
        }
    }
}
