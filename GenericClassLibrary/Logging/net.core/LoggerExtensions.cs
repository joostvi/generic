using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace GenericClassLibrary.Logging.net.core
{
    public static class LoggerExtensions
    {
        public static ILoggingBuilder AddMyConsoleLogger(this ILoggingBuilder builder)
        {
            //nothing to do with builder. Just to fit in framework.
            Logger.AddLogger(new ConsoleLogger());
            return builder;
        }

        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, string path, string baseFileName)
        {
            //nothing to do with builder. Just to fit in framework.
            Logger.AddLogger(new FileLogger(path, baseFileName));
            return builder;
        }

        public static ILoggingBuilder SetupProvider(this ILoggingBuilder builder)
        {
            builder.ClearProviders(); //Remove any default provider otherwise every thing will be logged to the console twice.
            builder.AddProvider(new LogProvider());
            return builder;
        }

        /// <summary>
        /// Sets the loglevel in the "Logger" class
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ILoggerFactory SetupLogLevel(this ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            Logger.Level = EnumLogLevel.Info;
            var logSettings = configuration["Logging:LogLevel:Default"]; //This is the ms default
            if (Enum.TryParse<Microsoft.Extensions.Logging.LogLevel>(logSettings, true, out var logValue))
            {
                Logger.Level = logValue.ToMyLogLevel();
            }
            return loggerFactory;
        }
    }
}
