using GenericClassLibrary.Logging;
using System;
using Xunit;

namespace GenericClassLibraryTests
{
    [Collection("ConsoleLoggerTests")]
    public class ConsoleLoggerTests
    {
        [Fact]
        public void Error_ConsoleCollorShouldNotChange()
        {
            ConsoleLogger cl = new ConsoleLogger();
            ConsoleColor cc = Console.ForegroundColor;
            cl.Error("some text");
            Assert.Equal(cc, Console.ForegroundColor);
        }

        [Fact]
        public void Warning_ConsoleCollorShouldNotChange()
        {
            ConsoleLogger cl = new ConsoleLogger();
            ConsoleColor cc = Console.ForegroundColor;
            cl.Warning("some text");
            Assert.Equal(cc, Console.ForegroundColor);
        }

        [Fact]
        public void Debug_ConsoleCollorShouldNotChange()
        {
            ConsoleLogger cl = new ConsoleLogger();
            ConsoleColor cc = Console.ForegroundColor;
            cl.Debug("some text");
            Assert.Equal(cc, Console.ForegroundColor);
        }

        [Fact]
        public void Info_ConsoleCollorShouldNotChange()
        {
            ConsoleLogger cl = new ConsoleLogger();
            ConsoleColor cc = Console.ForegroundColor;
            cl.Info("some text");
            Assert.Equal(cc, Console.ForegroundColor);
        }
    }
}
