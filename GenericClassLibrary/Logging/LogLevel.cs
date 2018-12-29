
namespace GenericClassLibrary.Logging
{
    public class LogLevel
    {
        public EnumLogLevel Level { get; }
        public string Description => Level.ToString();

        public LogLevel(EnumLogLevel level)
        {
            Level = level;
        }
    }
}
