using Xunit;
using GenericClassLibrary.Extensions;

namespace GenericClassLibraryTests
{
    public class TestStringExtensions
    {
        [Fact]
        public void ReplaceDuplicateSpace()
        {
            string input = "bla  bla";
            string output = input.ReplaceDuplicateSpace(true);

            Assert.Equal("bla bla", output);
        }

        [Fact]
        public void ReplaceDuplicateSpace_NoReplaceAtStart()
        {
            string input = "  bla  bla";
            string output = input.ReplaceDuplicateSpace(true);

            Assert.Equal("  bla bla", output);
        }

        [Fact]
        public void ReplaceDuplicateSpace_NoReplaceAtEnd()
        {
            string input = "bla  bla  ";
            string output = input.ReplaceDuplicateSpace(true);

            Assert.Equal("bla bla  ", output);
        }

        [Fact]
        public void ReplaceDuplicateSpace_Numbers()
        {
            string input = "bla1  2bla";
            string output = input.ReplaceDuplicateSpace(true);

            Assert.Equal("bla1 2bla", output);
        }

        [Fact]
        public void ReplaceDuplicateSpace_ReplaceAtEndAsWell()
        {
            string input = "bla  bla  ";
            string output = input.ReplaceDuplicateSpace(false);

            Assert.Equal("bla bla ", output);
        }

        [Fact]
        public void ReplaceDuplicateSpace_ReplaceAtStartAsWell()
        {
            string input = "  bla  bla";
            string output = input.ReplaceDuplicateSpace(false);

            Assert.Equal(" bla bla", output);
        }
    }
}
