using GenericClassLibrary.Logging;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using GenericClassLibrary.Logging.net.core;

namespace GenericClassLibraryTests
{
    [Collection("LoggingTests")]
    public class LoggingTests
    {
        [Fact]
        public void Logger_Error_Test()
        {
            //setup
            Mock<ILogger> logger = new Mock<ILogger>();
            Logger.AddLogger(logger.Object);
            Logger.Level = EnumLogLevel.Error;

            //act
            string logText = "Some error info to log";
            Logger.Error(logText);

            //verify
            logger.Verify(a => a.Error(logText));
        }

        [Fact]
        public void Logger_Info_Test()
        {
            //setup
            Mock<ILogger> logger = new Mock<ILogger>();
            Logger.AddLogger(logger.Object);
            Logger.Level = EnumLogLevel.Info;

            //act
            string logText = "Some error info to log";
            Logger.Info(logText);

            //verify
            logger.Verify(a => a.Info(logText));
        }

        [Fact]
        public void Logger_Debug_Test()
        {
            //setup
            Mock<ILogger> logger = new Mock<ILogger>();
            Logger.AddLogger(logger.Object);
            Logger.Level = EnumLogLevel.Debug;

            //act
            string logText = "Some error info to log";
            Logger.Debug(logText);

            //verify
            logger.Verify(a => a.Debug(logText));
        }

        [Fact]
        public void Logger_Warning_Test()
        {
            //setup
            Mock<ILogger> logger = new Mock<ILogger>();
            Logger.AddLogger(logger.Object);
            Logger.Level = EnumLogLevel.Warning;

            //act
            string logText = "Some warning info to log";
            Logger.Warning(logText);

            //verify
            logger.Verify(a => a.Warning(logText));
        }

        [Fact]
        public void Logger_MultipleLoggers_Test()
        {
            //setup
            Mock<ILogger> logger1 = new Mock<ILogger>();
            Logger.AddLogger(logger1.Object);
            Mock<ILogger> logger2 = new Mock<ILogger>();
            Logger.AddLogger(logger2.Object);
            Logger.Level = EnumLogLevel.Debug;

            //act
            string logText = "Some error info to log";
            Logger.Debug(logText);

            //verify
            logger1.Verify(a => a.Debug(logText));
            logger2.Verify(a => a.Debug(logText));
        }

        [Fact]
        public void Logger_LevelHigherThenRequested_Test()
        {
            //setup
            Mock<ILogger> logger = new Mock<ILogger>();
            Logger.AddLogger(logger.Object);
            Logger.Level = EnumLogLevel.Info;

            //act
            string logText = "Some error info to log";
            Logger.Debug(logText);

            //verify
            logger.Verify(a => a.Debug(logText), Times.Never);
        }

        [Fact]
        public void Logger_LevelLowerThenRequested_Test()
        {
            //setup
            Mock<ILogger> logger = new Mock<ILogger>();
            Logger.AddLogger(logger.Object);
            Logger.Level = EnumLogLevel.Info;

            //act
            string logText = "Some error info to log";
            Logger.Error(logText);

            //verify
            logger.Verify(a => a.Error(logText));
        }

        [Fact]
        public void LogLevelList_ContainsAllItems_Test()
        {
            LogLevelList logLevels = new LogLevelList();
            Array valuesAsArray = Enum.GetValues(typeof(EnumLogLevel));

            Assert.Equal(valuesAsArray.Length, logLevels.Count);
        }

        [Fact]
        public void LogMessageHelper_CreateMessageWithDictValues_NullDictionary_ExpectMessageReturned()
        {
            IDictionary<string, string> dict = null;
            var message = dict.CreateMessageWithDictValues("This is the message");

            Assert.Equal("This is the message", message.Message);
            Assert.Empty(message.Args);
        }

        [Fact]
        public void LogMessageHelper_CreateMessageWithDictValues_EmptyDictionary_ExpectMessageReturned()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            var message = dict.CreateMessageWithDictValues("This is the message");

            Assert.Equal("This is the message", message.Message);
            Assert.Empty(message.Args);
        }

        [Fact]
        public void LogMessageHelper_CreateMessageWithDictValues_NoMessage_ExpectMessageContainsValueList()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>
            {
                { "key1", "value1" }
            };
            var message = dict.CreateMessageWithDictValues(null);

            Assert.Equal("key1: {key1}", message.Message);
            Assert.Single(message.Args);
            Assert.Equal("value1", message.Args[0]);
        }

        [Fact]
        public void LogMessageHelper_CreateMessageWithDictValues_MultipleProps_ExpectMultipleBack()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };
            var message = dict.CreateMessageWithDictValues(null);

            Assert.Equal("key1: {key1}, key2: {key2}", message.Message);
            Assert.Equal(2, message.Args.Length);
            Assert.Equal("value1", message.Args[0]);
            Assert.Equal("value2", message.Args[1]);
        }
    }
}
