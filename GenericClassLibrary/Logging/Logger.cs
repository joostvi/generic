﻿using GenericClassLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClassLibrary.Logging
{
    public partial class Logger
    {
        //TODO decide about locking private static object _lock = new object();
        private static readonly List<ILogger> _loggers = new();

        public static EnumLogLevel Level { get; set; }

        public static void RemoveAll()
        {
            _loggers.Clear();
        }

        public static void Remove(ILogger logger)
        {
            if (_loggers.Contains(logger))
            {
                _loggers.Remove(logger);
            }
        }

        public static void AddLogger(ILogger logger)
        {
            if(_loggers.Contains(logger))
            {
                //nothing to do already added;
                return;
            }
            _loggers.Add(logger);
        }

        public static bool IsEnabled(EnumLogLevel level)
        {
            return level <= Level;
        }

        public static void Log(EnumLogLevel level, string value)
        {
            DoLog(level, value);
        }

        private static void DoLog(EnumLogLevel level, string value)
        {
            if (!IsEnabled(level))
            {
                return;
            }

            foreach (ILogger logger in _loggers)
            {
                switch (level)
                {
                    case EnumLogLevel.Trace:
                        logger.Trace(value);
                        break;
                    case EnumLogLevel.Error:
                        logger.Error(value);
                        break;
                    case EnumLogLevel.Info:
                        logger.Info(value);
                        break;
                    case EnumLogLevel.Debug:
                        logger.Debug(value);
                        break;
                    case EnumLogLevel.Warning:
                        logger.Warning(value);
                        break;
                    case EnumLogLevel.Critical:
                        logger.Critical(value);
                        break;
                }
            }
        }

        public static void Error(string value)
        {
            DoLog(EnumLogLevel.Error, value);
        }

        public static void Error(string value, Exception ex)
        {
            StringBuilder sb = new ();
            if (value != null)
            {
                sb.Append("ERROR: ");
                sb.AppendLine(value);
            }
            if (ex != null)
            {
                if (ex is InvalidInputException)
                {
                    sb.Append("\tMessage: ");
                    sb.AppendLine(ex.Message);
                }
                else
                {
                    sb.Append("\tException type: ");
                    sb.AppendLine(ex.GetType().ToString());
                    sb.Append("\tMessage: ");
                    sb.AppendLine(ex.Message);
                    sb.Append("\tStackTrace: ");
                    sb.AppendLine(ex.StackTrace);
                }
            }
            DoLog(EnumLogLevel.Error, sb.ToString());
        }

        public static void Warning(string value)
        {
            DoLog(EnumLogLevel.Warning, value);
        }

        public static void Info(string value)
        {
            DoLog(EnumLogLevel.Info, value);
        }

        public static void Debug(string value)
        {
            DoLog(EnumLogLevel.Debug, value);
        }

        public static void Critical(string value)
        {
            DoLog(EnumLogLevel.Critical, value);
        }

        public static void Trace(string value)
        {
            DoLog(EnumLogLevel.Trace, value);
        }
    }
}
