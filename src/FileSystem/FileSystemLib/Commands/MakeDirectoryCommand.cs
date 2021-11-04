using FileSystemLib.Exceptions;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class MakeDirectoryCommand : ICommander
    {
        public string Command { get; } = "make directory";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var name = words[2];
            // Verify there is no directory with the same name
            if (current.Children.Any(c => c.Name == name))
                throw new FileSystemArgumentException($"{name} directory already exist");

            // Create a new directory
            _ = new InMemoryDirectory(name, current);
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.StartsWith(Command) && parms.Split(" ").Length == 3;
        }
    }
}
