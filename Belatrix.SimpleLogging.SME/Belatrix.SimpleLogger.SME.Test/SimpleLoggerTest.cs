using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Belatrix.SimpleLogger.SME.Repository;
using Belatrix.SimpleLogger.SME.BE;
using Belatrix.SimpleLogger.SME.DL;
using Belatrix.SimpleLogger.SME.DL.DataProviders;
using System.Configuration;
using Belatrix.SimpleLogger.SME.Support;
using Belatrix.SimpleLogger.SME.LogEvent;

namespace Belatrix.SimpleLogger.SME.Test
{
    /// <summary>
    /// Summary description for SimpleLoggerTest
    /// </summary>
    [TestClass]
    public class SimpleLoggerTest
    {
        public readonly ILoggerRepository MockLoggerRepository;
        public SimpleLoggerTest()
        {
            //
            // TODO: Add constructor logic here
            //
            var mockLoggerRepository = new Mock<ILoggerRepository>();
            mockLoggerRepository.Setup(m => m.LogMessage(It.IsAny<Logger>())).Returns(Constants.DBSuccessLog);
            MockLoggerRepository = mockLoggerRepository.Object;
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void GetConnStringFromAppConfig()
        {
            //Arrange
            var testRepository = new DBLoggerConnection();
            string actualString = testRepository.SqlConnectionString;
            string expectedString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            //Assert
            Assert.IsNotNull(expectedString);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void SaveLogMessageToDataBaseTest()
        {
            //Arrange
            var logTest = new Logger()
            {
                LogSeverity = 1,
                Message = "UnitTest:Log message to the DataBase Test"
            };
            var loggerRepository = new LoggerRepositoryDB();
            var resultMessage = loggerRepository.LogMessage(logTest);
            //Assert
            Assert.IsNotNull(resultMessage);
            Assert.AreNotEqual(resultMessage, string.Empty);
            Assert.AreEqual(Constants.DBSuccessLog, resultMessage);
        }

        [TestMethod]
        public void LogMessageToConsoleTest()
        {
            //Arrange 
            var logTest = new Logger()
            {
                LogSeverity = 1,
                Message = "UnitTest: Log message to the console"
            };
            var loggerRepositoryEvent = new LoggerRepositoryEvents();
            var resultMessage = loggerRepositoryEvent.LogMessage(logTest);
            var expectedMessage = $"Log Details: LogMessage = {logTest.Message}, LogSeverity = {Constants.Warning}";
            //Asserts
            Assert.IsNotNull(resultMessage);
            Assert.AreNotEqual(resultMessage, string.Empty);
            Assert.IsTrue(resultMessage.Length > 0);
            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [TestMethod]
        public void LogMessageInterfaseByUsingMoqTest()
        {
            //Arrange 
            var logTest = new Logger()
            {
                LogSeverity = 2,
                Message = "UnitTest: Log message to the console"
            };
            var resultMessage = MockLoggerRepository.LogMessage(logTest);
            //Asserts
            Assert.IsNotNull(resultMessage);
            Assert.AreEqual(Constants.DBSuccessLog, resultMessage);
        }
    }
}
