using GenericClassLibrary.Logging;
using System.IO;

namespace GenericClassLibrary.FileSystem.Compare
{
    public class FileComparer : IFileComparer
    {
        public bool IsSameFile(FileInfo file1, FileInfo file2)
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
                    //We should probably compare content but for now we assume the same name and length as the same.
                    sameFile = HasSameContent(file1, file2);
                }
            }
            return sameFile;
        }

        private static bool HasSameContent(FileInfo file1, FileInfo file2)
        {
            // Open the two files.
            FileStream fs1 = new(file1.FullName, FileMode.Open);
            FileStream fs2 = new(file2.FullName, FileMode.Open);

            bool sameFile = false;
            try
            {
                // Check the file sizes. If they are not the same, the files are not the same.
                if (fs1.Length == fs2.Length)
                {
                    int file1byte;
                    int file2byte;
                    // Read and compare a byte from each file until either a
                    // non-matching set of bytes is found or until the end of
                    // file1 is reached.
                    do
                    {
                        // Read one byte from each file.
                        file1byte = fs1.ReadByte();
                        file2byte = fs2.ReadByte();
                    }
                    while (((file1byte == file2byte) && file1byte != -1 && file2byte != -1));

                    sameFile = (file1byte == file2byte);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                Logger.Debug("Finalizing");
                // Close the files.
                fs1.Close();
                fs2.Close();
                fs1.Dispose();
                fs2.Dispose();
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
                sameFile = HasSameContent(new FileInfo(file1), new FileInfo(file2));
            }
            return sameFile;
        }
    }
}
