using System;

namespace FileSystemLib.Commands
{
    public class ChangeToParentCommand : ICommander
    {
        public string Command { get; } = "change directory to parent";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            if (current.Parent == null)
                return current;
            return current.Parent;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.Equals(Command, StringComparison.OrdinalIgnoreCase); 
        }
    }
}
