using System.Collections.Generic;
using System.Linq;
using MsLogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace GenericClassLibrary.Logging.net.core
{
    public class LogMessage
    {
        public string Message { get; }
        public object[] Args { get; }

        public LogMessage(string message, object[] args)
        {
            Message = message;
            Args = args;
        }
    }

    public static class LogHelper
    {
        /// <summary>
        /// The .net core logging structure will try to replace values in a message based on their naming.
        /// So for example when text is "Failed to complete action! State: {State}" it expect a value in the Args in for example "_logger.LogInformation(message, args)" to have at least one element which will replace "{State}" if you use the default formatter.
        /// This method will add the key value pairs to the message. So it will at "State: {State}" when it finds the key "State" in the dictionary and will add the value to args.
        /// </summary>
        /// <param name="dict">Dictionary with key value pairs to be added to the message.</param>
        /// <param name="message">The log message.</param>
        /// <returns></returns>
        public static LogMessage CreateMessageWithDictValues(this IDictionary<string, string> dict, string message)
        {
            if(dict == null || !dict.Any())
            {
                return new LogMessage(message, System.Array.Empty<string>());
            }
            object[] args = new string[dict.Count];
            string props = string.Empty;
            int i = 0;
            foreach (var pair in dict)
            {
                args[i] = pair.Value;
                if (props.Length > 0) props += ", ";
                props += $"{pair.Key}: {{{pair.Key}}}";
                i += 1;
            }
            return new LogMessage(message += props, args);
        }

        public static EnumLogLevel ToMyLogLevel(this MsLogLevel logLevel)
        {
            return logLevel switch
            {
                MsLogLevel.Information => EnumLogLevel.Info,
                MsLogLevel.Error => EnumLogLevel.Error,
                MsLogLevel.Warning => EnumLogLevel.Warning,
                MsLogLevel.Debug => EnumLogLevel.Debug,
                MsLogLevel.Critical => EnumLogLevel.Critical,
                MsLogLevel.Trace => EnumLogLevel.Trace,
                _ => EnumLogLevel.None,
            };
        }
    }
}
