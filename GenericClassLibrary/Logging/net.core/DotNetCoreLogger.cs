using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MsLogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace GenericClassLibrary.Logging.net.core
{
    public class DotNetCoreLogger : Microsoft.Extensions.Logging.ILogger
    {
        public LogProvider LogProvider { get; }
        public string CategoryName { get; }
        public DotNetCoreLogger(LogProvider logProvider, string categoryName)
        {
            LogProvider = logProvider;
            CategoryName = categoryName;
        }

        private class ScopeTest<TState> : IDisposable
        {
            public TState State { get; }
            public ScopeTest(TState state)
            {
                State = state;
            }
            public void Dispose()
            {

            }
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return LogProvider.ScopeProvider.Push(state);
        }

        public bool IsEnabled(MsLogLevel logLevel)
        {
            return Logger.IsEnabled(logLevel.ToMyLogLevel());
        }

        private static void Log(MsLogLevel logLevel, string value)
        {
            switch (logLevel)
            {
                case MsLogLevel.Information:
                    Logger.Info(value);
                    break;
                case MsLogLevel.Error:
                    Logger.Error(value);
                    break;
                case MsLogLevel.Warning:
                    Logger.Warning(value);
                    break;
                case MsLogLevel.Debug:
                    Logger.Debug(value);
                    break;
                case MsLogLevel.Critical:
                    Logger.Critical(value);
                    break;
                case MsLogLevel.Trace:
                    Logger.Trace(value);
                    break;
                case MsLogLevel.None:
                    break;
                default:
                    throw new NotImplementedException(logLevel.ToString() + " is not implemented!");
            }
        }

        public void Log<TState>(MsLogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = string.Empty;
            if (formatter != null)
            {
                message = formatter.Invoke(state, exception);
            }
            string logMessage = $"CategoryName: {CategoryName}, EventId: {eventId.Id}/{eventId.Name}, Message: {message}";

            string scopeData = string.Empty;
            if (LogProvider.ScopeProvider != null)
            {
                LogProvider.ScopeProvider.ForEachScope((value, loggingProps) =>
                    {
                        if (value is string)
                        {
                            scopeData = value.ToString();
                        }
                        else if (value is IEnumerable<KeyValuePair<string, object>> props)
                        {
                            foreach (var pair in props)
                            {
                                scopeData += $"{pair.Key} - {pair.Value}";
                            }
                        }
                    },
                    state);
            }
            if (scopeData != string.Empty) scopeData += "\r\n";
            Log(logLevel, scopeData + logMessage);
        }
    }
}
