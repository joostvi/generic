using System;
using System.Diagnostics;

namespace GenericClassLibrary.Logging
{
    public class TimeLogger
    {
        public string Action { get; }
        public EnumLogLevel LogLevel { get; }

        private Stopwatch _stopwatch;

        public TimeLogger(EnumLogLevel logLevel, string action)
        {
            Action = action;
            LogLevel = logLevel;
        }
        public void Start()
        {
            if (Logger.Level >= LogLevel)
            {
                if (_stopwatch != null)
                {
                    throw new Exception("Timer already started!");
                }
                _stopwatch = new Stopwatch();
                _stopwatch.Start();
            }
        }

        public void Stop()
        {
            if (_stopwatch == null)
            {
                return;
            }

            _stopwatch.Stop();
            Logger.Info($"{Action} took {_stopwatch.ElapsedMilliseconds} ms.");
        }
    }
}
