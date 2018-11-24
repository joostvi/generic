using GenericClassLibrary.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenericClassLibraryTests.Mocks
{
    public class FileMock : IFile
    {
        private readonly DirectoryMock _Directory;

        public IList<string> Files { get; } = new List<string>();

        public FileMock(DirectoryMock directory)
        {
            _Directory = directory;
        }

        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            string path = destFileName.Substring(0, destFileName.LastIndexOf("\\"));
            if (!_Directory.Directories.Contains(path) )
            {
                throw new DirectoryNotFoundException();
            }
            Files.Add(destFileName);
        }

        public void Delete(string path)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string path)
        {
            return Files.Contains(path);
        }

        public void Move(string sourceFileName, string destFileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In real world GetExtension returns the extension inclusive dot (Path.GetExtension(aFile))
        /// </summary>
        /// <param name="aFile">Input filename</param>
        /// <returns></returns>
        public string GetExtension(string aFile)
        {
            string[] splits = aFile.Split('.');
            if(splits.Length <= 1)
            {
                //When no extension "" is returned
                return "";
            }
            string last = splits.Last(b => b != null && b != "");
            if(last.Length > 0 && !last[0].Equals('.'))
            {
                last = "." + last;
            }
            return last;
        }
    }
}
