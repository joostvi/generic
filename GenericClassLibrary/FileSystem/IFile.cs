﻿namespace GenericClassLibrary.FileSystem
{
    public interface IFile
    {
        void Copy(string sourceFileName, string destFileName, bool overwrite);
        void Delete(string path);
        bool Exists(string path);
        void Move(string sourceFileName, string destFileName);

        string GetExtension(string aFile);
    }
}