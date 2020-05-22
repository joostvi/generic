
using GenericClassLibrary.Logging;

namespace GenericWPFLibrary.Usercontrol.WpfScreenLogger
{
    public class ScreenLogEventArgs
    {
        public EnumLogLevel Level { get; }
        public string Value { get; }

        public ScreenLogEventArgs(EnumLogLevel level, string value)
        {
            Level = level;
            Value = value;
        }
    }
}
