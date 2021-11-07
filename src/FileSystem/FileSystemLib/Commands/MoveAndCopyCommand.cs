using FileSystemLib.Enums;
using FileSystemLib.Exceptions;
using System.Linq;

namespace FileSystemLib.Commands
{
    public class MoveAndCopyCommand : ICommander
    {
        public string Command { get; } = "move file";
        public string CopyCommand { get; } = "copy file";

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

            if (parms.StartsWith(Command))
            {
                // Move file to the InMemoryDirectory
                MoveToDirectory(targetFile, targetDirectoryObj);
            }
            else if (parms.StartsWith(CopyCommand))
            {
                // Copy File to the targeDirectory
                CopyToDirectory(targetFile, targetDirectoryObj);
            }
            else 
            {
                throw new FileSystemArgumentException($"Invalid command");
            }
            return current;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return (parms.StartsWith(Command) && parms.Split(" ").Length == 4)
                || (parms.StartsWith(CopyCommand) && parms.Split(" ").Length == 4);
        }

        private void MoveToDirectory(IInMemoryFile file, InMemoryDirectory targetDirectory)
        {
            file.Parent.Children.Remove(file);
            file.Parent = targetDirectory;
            targetDirectory.Children.Add(file);
        }

        private void CopyToDirectory(IInMemoryFile file, InMemoryDirectory targetDirectory)
        {
            if (file.FileType == InMemoryFileType.Directory)
            {
                // Create a new Directory
                var newDirectory = new InMemoryDirectory(file.Name, targetDirectory);
                InMemoryDirectory currentDirectory = (InMemoryDirectory)file;
                foreach (var child in currentDirectory.Children)
                {
                    // Copy child to the newDirectory
                    CopyToDirectory(child, newDirectory);
                }
            }
            else
            {
                // Create a new file
                var newFile = new InMemoryFile(file.Name, targetDirectory);
                InMemoryFile currentFile = (InMemoryFile)file;
                newFile.Contents = currentFile.Contents;
            }
        }
    }
}
