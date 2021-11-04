using FileSystemLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemLib.Commands
{
    public class FindFileCommand : ICommander
    {
        public string Command { get; } = "find file";

        public InMemoryDirectory Execute(string parms, InMemoryDirectory current)
        {
            var words = parms.Split(" ");
            var outputMessage = string.Join(", ", FindFile(words[2], current));
            Console.WriteLine(outputMessage);
            return current;
        }

        private static List<string> FindFile(string fileName, InMemoryDirectory current)
        {
            // Find a file in the children
            var result = new List<string>();
            if (current.Children.Any(c => c.FileType == InMemoryFileType.File && c.Name == fileName))
            {
                string path = current.Path != "/" ? current.Path + "/" : current.Path;
                result.Add($"{path}{fileName}");
            }

            foreach (var child in current.Children.Where(c => c.FileType == InMemoryFileType.Directory))
            {
                result.AddRange(FindFile(fileName, (InMemoryDirectory)child));
            }
            return result;
        }

        public bool IsValidCommandAndParams(string parms)
        {
            return parms.StartsWith(Command) && parms.Split(" ").Length == 3;
        }
    }
}
