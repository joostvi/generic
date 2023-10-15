using GenericClassLibrary.FileSystem.Compare;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace GenericClassLibraryTests.FileSystem
{
    [Collection("TestSimpleFileComparer")]
    public class TestSimpleFileComparer
    {

        private static SimpleFileComparer SimpleFileComparer => new (Substitute.For<ILogger>());

        [Fact]
        public void IsSameFile_String1_String2_BothNull_Expect_True()
        {
            string file1 = null;
            string file2 = null;
            Assert.True(SimpleFileComparer.IsSameFile(file1, file2));
        }

        [Theory]
        [InlineData(null, "someValue")]
        [InlineData("someValue", null)]
        public void IsSameFile_String1_String2_OneNull_Expect_False(string file1, string file2)
        {
            Assert.False(SimpleFileComparer.IsSameFile(file1, file2));
        }
    }
}
