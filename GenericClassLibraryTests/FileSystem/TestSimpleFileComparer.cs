using GenericClassLibrary.FileSystem.Compare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericClassLibraryTests.FileSystem
{
    [Collection("TestSimpleFileComparer")]
    public class TestSimpleFileComparer
    {

        private SimpleFileComparer SimpleFileComparer => new SimpleFileComparer();

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
