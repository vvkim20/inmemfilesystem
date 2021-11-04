using FileSystemLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemLib.Commands
{
    public class DeleteDirectoryCommand : ICommander
    {
        public string Command { get; } = "delete directory";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var fileName = words[2];
            if (!current.Children.Any(c => c.FileType == Enums.InMemoryFileType.Directory && c.Name == fileName))
                throw new FileSystemArgumentException($"{fileName} {Enums.InMemoryFileType.Directory} doesn't exist");

            var targetFile = (InMemoryDirectory)current.Children.Single(c => c.FileType == Enums.InMemoryFileType.Directory && c.Name == fileName);
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
