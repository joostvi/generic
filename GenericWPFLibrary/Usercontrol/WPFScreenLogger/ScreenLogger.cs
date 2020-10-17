using GenericClassLibrary.Logging;
using System;

namespace GenericWPFLibrary.Usercontrol.WpfScreenLogger
{
    public class ScreenLogger : ILogger
    {

        public event EventHandler<ScreenLogEventArgs> LogEventHandler;

        public ScreenLogger(EventHandler<ScreenLogEventArgs> logEventHandler)
        {
            LogEventHandler = logEventHandler;
        }

        private void DoLog(EnumLogLevel level, string value)
        {
            LogEventHandler?.Invoke(this, new ScreenLogEventArgs(level, value));
        }

        public void Debug(string value)
        {
            DoLog(EnumLogLevel.Debug, value);
        }

        public void Error(string value)
        {
            DoLog(EnumLogLevel.Error, value);
        }

        public void Info(string value)
        {
            DoLog(EnumLogLevel.Info, value);
        }

        public void Warning(string value)
        {
            DoLog(EnumLogLevel.Warning, value);
        }

        public void Critical(string value)
        {
            DoLog(EnumLogLevel.Critical, value);
        }
    }
}
