using Microsoft.Extensions.Logging;

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
