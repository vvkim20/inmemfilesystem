using FileSystemLib.Enums;
using FileSystemLib.Exceptions;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class ChangeDirectoryCommand : ICommander
    {
        public string Command { get; } = "change directory to";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var directory = words[3];

            if (!current.Children.Any(c => c.FileType == InMemoryFileType.Directory && c.Name == directory))
                throw new FileSystemArgumentException($"{directory} directory doesn't exist");

            return (InMemoryDirectory)current.Children.Single(c => c.FileType == InMemoryFileType.Directory && c.Name == directory);
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.StartsWith(Command) && parms.Split(" ").Length == 4;
        }
    }
}
