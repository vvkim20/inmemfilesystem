using FileSystemLib.Exceptions;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class CreateFileCommand : ICommander
    {
        public string Command { get; } = "make file";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var name = words[2];
            // Verify there is no directory with the same name
            if (current.Children.Any(c => c.Name == name))
                throw new FileSystemArgumentException($"{name} file already exist");

            //  Create a new file
            _ = new InMemoryFile(name, current);
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.StartsWith(Command) && parms.Split(" ").Length == 3;
        }
    }
}
