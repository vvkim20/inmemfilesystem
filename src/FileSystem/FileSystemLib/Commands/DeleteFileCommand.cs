using FileSystemLib.Exceptions;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class DeleteFileCommand : ICommander
    {
        public string Command { get; } = "delete file";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var fileName = words[2];
            if (!current.Children.Any(c => c.FileType == Enums.InMemoryFileType.File && c.Name == fileName))
                throw new FileSystemArgumentException($"{fileName} {Enums.InMemoryFileType.File} doesn't exist");

            var targetFile = (InMemoryDirectory)current.Children.Single(c => c.FileType == Enums.InMemoryFileType.File && c.Name == fileName);
            targetFile.Parent = null;
            current.Children.Remove(targetFile);
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.StartsWith(Command) && parms.Split(" ").Length == 3;
        }
    }
}
