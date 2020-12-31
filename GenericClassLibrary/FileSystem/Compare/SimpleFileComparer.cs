using GenericClassLibrary.Logging;
using System.IO;

namespace GenericClassLibrary.FileSystem.Compare
{
    public class SimpleFileComparer : IFileComparer
    {
        public bool IsSameFile(FileInfo aFile, FileInfo aFile2)
        {
            return CheckIfIsSameFile(aFile, aFile2);
        }

        private static bool CheckIfIsSameFile(FileInfo file1, FileInfo file2)
        {
            bool sameFile = false;

            if (file1 == null && file2 == null)
            {
                sameFile = true;
            }
            else if (file1 == null || file2 == null)
            {
                // if one is nothing then the other is not.
                sameFile = false;
            }
            else
            {    // we have to look into the file details
                 // Cannot use creation time as this will be changed during backup.
                 // TimeSpan diffResult = aFile.LastWriteTimeUtc.Subtract(aFile2.LastWriteTimeUtc);
                 //var hashCode1 = aFile.GetHashCode();
                 //var hashCode2 = aFile2.GetHashCode();
                Logger.Debug($"FileComparer: length 1: {file1.Length}, length 2: {file2.Length}, name 1: {file1.Name}, name 2: {file2.Name}");
                if (file1.Length == file2.Length && file1.Name == file2.Name)
                {
                    //We keep it simple so only check on length and name.
                    sameFile = true;
                }
            }
            return sameFile;
        }


        // This method accepts two strings the represent two files to 
        // compare. A return value of true indicates that the contents of the files
        // are the same. 
        public bool IsSameFile(string file1, string file2)
        {
            bool sameFile;
            // ' Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                sameFile = true;
            }
            else if (file1 == null || file2 == null)
            {
                // if one is nothing then the other is not.
                sameFile = false;
            }
            else
            {
                sameFile = CheckIfIsSameFile(new FileInfo(file1), new FileInfo(file2));
            }
            return sameFile;
        }
    }
}
