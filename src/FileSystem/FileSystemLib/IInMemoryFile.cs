using FileSystemLib.Enums;
using System.Collections.Generic;

namespace FileSystemLib
{
    public interface IInMemoryFile
    {
        InMemoryFileType FileType { get; }
        InMemoryDirectory Parent { get; set; }
        string Name { get; set; }
        //void MoveToDirectory(InMemoryDirectory targetDirectory);
        //void CopyToDirectory(InMemoryDirectory targetDirectory);
    }
}
