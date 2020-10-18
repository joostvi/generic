
namespace GenericClassLibrary.Logging
{
    public interface ILogger
    {
        void Trace(string value);
        void Error(string value);
        void Info(string value);
        void Debug(string value);
        void Warning(string value);

        void Critical(string value);
    }
}
