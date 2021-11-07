using FileSystemLib.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemLib.Commands
{
    /// <summary>
    /// Should be 
    /// </summary>
    public class FileCommands
    {
        private List<ICommander> commanders = new List<ICommander>();
        public FileCommands()
        {
            commanders.Add(new ChangeToParentCommand());
            commanders.Add(new MoveAndCopyCommand());
            commanders.Add(new FindFileCommand());
            commanders.Add(new DeleteFileCommand());
            commanders.Add(new GetFileCommand());
            commanders.Add(new ChangeDirectoryCommand());
            commanders.Add(new MakeDirectoryCommand());
            commanders.Add(new CreateFileCommand());
            commanders.Add(new UpdateFileCommand());
            commanders.Add(new GetCurrentDirectoryCommand());
            commanders.Add(new DeleteDirectoryCommand());
            commanders.Add(new ReadFileCommand());
        }

        public InMemoryDirectory ExecuteCommand(string param, InMemoryDirectory current)
        {
            var commander = commanders.FirstOrDefault(c => c.IsValidCommandAndParams(param));
            if (commander == null)
                throw new FileSystemArgumentException("Invalid command");

            return commander.Execute(param, current);
        }
    }
}
