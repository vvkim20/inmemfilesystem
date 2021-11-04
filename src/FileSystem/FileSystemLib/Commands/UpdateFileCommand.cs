using FileSystemLib.Enums;
using FileSystemLib.Exceptions;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class UpdateFileCommand : ICommander
    {
        public string Command { get; } = "write file";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var fileName = words[2];
            var contents = words[3];
            var targetFile = (InMemoryFile)current.Children.Single(c => c.FileType == InMemoryFileType.File && c.Name == fileName);

            // Verify there is no directory with the same name
            if (targetFile == null)
                throw new FileSystemArgumentException($"{fileName} file doesn't exist");

            //  Create a new file
            targetFile.Contents = contents;
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.StartsWith(Command);
        }
    }
}
