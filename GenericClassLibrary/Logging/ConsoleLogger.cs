using System;

namespace GenericClassLibrary.Logging
{
    public class ConsoleLogger : ILogger
    {
        private static void WriteLine(string text, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }

        public void Trace(string value)
        {
            WriteLine(value, ConsoleColor.White);
        }

        public void Debug(string value)
        {
            WriteLine(value, ConsoleColor.White);
        }

        public void Error(string value)
        {
            WriteLine(value, ConsoleColor.Red);
        }

        public void Info(string value)
        {
            WriteLine(value, ConsoleColor.White);
        }

        public void Warning(string value)
        {
            WriteLine(value, ConsoleColor.Yellow);
        }

        public void Critical(string value)
        {
            WriteLine(value, ConsoleColor.Red);
        }
    }

    public static class ConsoleLoggerExtensions
    {
        public static Logger AddConsoleLogger(this Logger logger)
        {
            Logger.AddLogger(new ConsoleLogger());
            return logger;
        }
    }
}
