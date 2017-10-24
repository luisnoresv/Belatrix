using Belatrix.SimpleLogger.SME.App.Infraestructure;
using Belatrix.SimpleLogger.SME.BE;
using Belatrix.SimpleLogger.SME.Repository;
using Belatrix.SimpleLogger.SME.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.SimpleLogger.SME.App
{
    class Program
    {
        //private static ILoggerRepository repository;
        static void Main(string[] args)
        {
            try
            {
                LogManager();
                string answer = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Yes (y) or No (n): ");
                    answer = Console.ReadLine();
                    var optionTyped = answer?.ToLower();
                    if ((optionTyped.Equals("y")))
                    {
                        LogManager();
                    }
                    else if ((optionTyped.Equals("n")))
                        break;
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        static void LogManager()
        {
            Console.WriteLine("Please type the log message");
            var logMessage = Console.ReadLine();
            Console.WriteLine("Type the number of the log type Severity: 1:TYPE_WARNING , 2:TYPE_SUCCESS,3: TYPE_ERROR");
            short logSeverity;
            Int16.TryParse(Console.ReadLine(), out logSeverity);
            var logger = new Logger()
            {
                LogSeverity = logSeverity,
                LogType = 0,
                Message = logMessage
            };
            ManageLogAssemblies(logger);
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.ReadLine();
        }

        static void ManageLogAssemblies(Logger logger)
        {
            try
            {
                string resultMessage = string.Empty;
                AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;

                AppDomain newDomain = AppDomain.CreateDomain(Constants.Domain, AppDomain.CurrentDomain.Evidence, setup); //Create an instance of loader class in new appdomain

                System.Runtime.Remoting.ObjectHandle obj = newDomain.CreateInstance(typeof(LoadMyAssembly).Assembly.FullName, typeof(LoadMyAssembly).FullName);

                LoadMyAssembly loader = (LoadMyAssembly)obj.Unwrap();
                foreach (var file in Directory.GetFiles(Constants.RootPath, Constants.AssemblyExtension))
                {
                    loader.LoadAssembly(file);
                    resultMessage = loader.ExecuteStaticLoggerMethod(logger);
                    if (!string.IsNullOrEmpty(resultMessage))
                    {
                        Console.WriteLine(resultMessage);
                    }
                    else
                        Console.WriteLine("Please add the correct assemblies to the [Plugins] folder");

                }
                if (string.IsNullOrEmpty(resultMessage))
                    Console.WriteLine("Please add the correct assemblies to the [Plugins] folder");
                AppDomain.Unload(newDomain);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
