using System;

namespace FileSystemLib
{
    public interface ICommander
    {
        string Command { get; set; }

        bool IsValidCommandAndParams(string[] parms);
    }


    public enum FileType
    { 
        Dictionary,
        File
    }
}
