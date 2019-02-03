﻿using GenericClassLibrary.Logging;
using System.Windows.Forms;

namespace GenericWinformsLibrary.Logging
{
    public class WinformsControlAttachedLogger : ILogger
    {
        readonly Control _control;
        private readonly UpdateLogTextDelegate _updateLogTextDelegate;

        public delegate void UpdateLogTextDelegate(EnumLogLevel logLevel, string line);

        public WinformsControlAttachedLogger(Control form1, UpdateLogTextDelegate richTextBox)
        {
            _control = form1;
            _updateLogTextDelegate = richTextBox;
        }

        private void AddLine(EnumLogLevel logLevel, string value)
        {
            _control.Invoke(new UpdateLogTextDelegate(_updateLogTextDelegate), logLevel, value);
        }

        public void Debug(string value)
        {
            AddLine(EnumLogLevel.Debug, value);
        }

        public void Error(string value)
        {
            AddLine(EnumLogLevel.Error, value);
        }

        public void Info(string value)
        {
            AddLine(EnumLogLevel.Info, value);
        }

        public void Warning(string value)
        {
            AddLine(EnumLogLevel.Warning, value);
        }
    }
}
