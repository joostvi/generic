using System;

namespace GenericClassLibrary.Logging
{
    public class ConsoleLogger : ILogger
    {

        public void Debug(string value)
        {
            Console.WriteLine("DEBUG: " + value);
        }

        public void Error(string value)
        {
            Console.WriteLine("ERROR: " + value);
        }

        public void Info(string value)
        {
            Console.WriteLine("INFO: " + value);
        }

        public void Warning(string value)
        {
            Console.WriteLine("WARNING: " + value);
        }
    }
}
