using Microsoft.Extensions.Logging;

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
    }
}
