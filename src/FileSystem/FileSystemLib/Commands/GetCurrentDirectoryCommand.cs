using System;

namespace FileSystemLib.Commands
{
    public class GetCurrentDirectoryCommand : ICommander
    {
        public string Command { get; } = "get working directory";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            Console.WriteLine(current.Path);
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.Equals(Command, StringComparison.OrdinalIgnoreCase);
        }
    }
}
