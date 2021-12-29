using Microsoft.Extensions.Logging;
using System;

namespace GenericClassLibrary.Logging.net.core
{
    public class LogProvider : ILoggerProvider
    {
        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return new DotNetCoreLogger(this, categoryName);
        }

        public void Dispose()
        {
            //nothing to do here
            GC.SuppressFinalize(this);
        }

        private IExternalScopeProvider _fScopeProvider;

        internal IExternalScopeProvider ScopeProvider
        {
            get
            {
                if (_fScopeProvider == null)
                    _fScopeProvider = new LoggerExternalScopeProvider();
                return _fScopeProvider;
            }
        }
    }
}
