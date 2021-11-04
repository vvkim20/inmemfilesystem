using FileSystemLib.Exceptions;
using System;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class ReadFileCommand : ICommander
    {
        public string Command { get; } = "read file";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var fileName = words[2];
            // check the file exist
            var targetFile = (InMemoryFile)current.Children.SingleOrDefault(c => c.FileType == Enums.InMemoryFileType.File && c.Name == fileName);

            // Verify there is no directory with the same name
            if (targetFile == null)
                throw new FileSystemArgumentException($"{fileName} file doesn't exist");

            Console.WriteLine($">> FileName: {targetFile.Name} \r\n Content: {targetFile.Contents}");
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.StartsWith(Command) && parms.Split(" ").Length == 3;
        }
    }
}
