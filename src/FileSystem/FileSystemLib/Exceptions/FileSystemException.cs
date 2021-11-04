using System;

namespace FileSystemLib.Exceptions
{
    public class FileSystemException : Exception
    {
        public FileSystemException(string message) : base(message)
        {
        }
    }
}
