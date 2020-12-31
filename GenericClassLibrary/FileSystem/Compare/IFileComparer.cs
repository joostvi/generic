using System.IO;

namespace GenericClassLibrary.FileSystem.Compare
{
    public interface IFileComparer
    {
        bool IsSameFile(FileInfo file1, FileInfo file2);
        bool IsSameFile(string file1, string file2);
    }
}
