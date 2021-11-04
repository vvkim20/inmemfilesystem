using FileSystemLib.Enums;
using FileSystemLib.Exceptions;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class MoveCommand : ICommander
    {
        public string Command { get; } = "move file";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var fileName = words[2];
            var targetDirectory = words[3];
            if (string.IsNullOrWhiteSpace(targetDirectory))
                throw new FileSystemArgumentException($"target directory is missing");

            // check the file exist
            var targetFile = current.Children.SingleOrDefault(c => c.Name == fileName);

            // Verify there is no directory with the same name
            if (targetFile == null)
                throw new FileSystemArgumentException($"{fileName} file doesn't exist");

            // Find a InMemoryDirectory by targetdirectory
            var paths = targetDirectory.Split("/");
            InMemoryDirectory targetDirectoryObj = current;
            foreach (var path in paths)
            {
                targetDirectoryObj = (InMemoryDirectory)targetDirectoryObj.Children.SingleOrDefault(c => c.FileType == InMemoryFileType.Directory && c.Name == path);
                if (targetDirectoryObj == null)
                    throw new FileSystemArgumentException($"target directory {targetDirectory} doesn't exist");
            }

            string newFileName = fileName;

            // Get a newfile name if the file name already exist
            while (true)
            {
                var dupeFile = targetDirectoryObj.Children.SingleOrDefault(c => c.Name == newFileName && c.FileType == targetFile.FileType);
                if (dupeFile == null)
                {
                    break;
                }
                else
                {
                    newFileName += "_copy";
                }
            }
            targetFile.Name = newFileName;

            // Move file to the InMemoryDirectory
            targetFile.MoveToDirectory(targetDirectoryObj);
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.StartsWith(Command) && parms.Split(" ").Length == 4;
        }
    }
}
