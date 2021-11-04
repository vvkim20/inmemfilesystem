using FileSystemLib.Enums;

namespace FileSystemLib
{
    public class InMemoryFile : IInMemoryFile
    {
        public InMemoryFileType FileType => InMemoryFileType.File;
        public InMemoryDirectory Parent { get; set; }
        public string Name { get; set; }

        public string Contents { get; set; }

        public InMemoryFile(string name, InMemoryDirectory parentDirectory)
        {
            Name = name;
            Parent = parentDirectory;
            parentDirectory.Children.Add(this);
        }

        /// <summary>
        /// Todo: move it to an abstract class
        /// </summary>
        /// <param name="targetDirectory"></param>
        public void MoveToDirectory(InMemoryDirectory targetDirectory)
        {
            Parent.Children.Remove(this);
            Parent = targetDirectory;
            targetDirectory.Children.Add(this);
        }
    }
}
