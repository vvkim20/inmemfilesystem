using System;

namespace FileSystemLib.Commands
{
    public interface ICommander
    {
        string Command { get; }

        bool IsValidCommandAndParams(string parms);

        InMemoryDirectory Execute(string parms, InMemoryDirectory current);
    }
}
