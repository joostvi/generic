using GenericClassLibrary.FileSystem;
using NSubstitute;

namespace GenericClassLibraryTests.Mocks
{
    public class FileSystemMoqHelper
    {
        public bool FileExists { get; set; }
        public bool DirectoryExists { get; set; }
        public bool IsDirectory { get; set; }

        public IFileSystem IFileSystemMock { get; private set; }
        public IFile IFileMock { get; private set; }
        public IDirectory IDirectoryMock { get; private set; }

        public void Setup()
        {
            IFileSystemMock = Substitute.For<IFileSystem>();
            IFileMock = Substitute.For<IFile>();
            IFileMock.Exists(Arg.Any<string>()).Returns(FileExists);

            IDirectoryMock = Substitute.For<IDirectory>();
            IDirectoryMock.Exists(Arg.Any<string>()).Returns(DirectoryExists);

            IFileSystemMock.File.Returns(IFileMock);
            IFileSystemMock.Directory.Returns(IDirectoryMock);
            IFileSystemMock.IsDirectory(Arg.Any<string>()).Returns(IsDirectory);
        }
    }
}
