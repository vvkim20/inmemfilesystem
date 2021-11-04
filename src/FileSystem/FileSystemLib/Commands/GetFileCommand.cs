using System;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class GetFileCommand : ICommander
    {
        public string Command { get; } = "get working directory contents";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var outputMessage = string.Join(", ", current.Children.Select(c => c.Name).ToList());
            Console.WriteLine($">> {outputMessage}");
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.Equals(Command, StringComparison.OrdinalIgnoreCase);
        }
    }
}
