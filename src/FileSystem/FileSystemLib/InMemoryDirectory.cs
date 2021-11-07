using FileSystemLib.Enums;
using System.Collections.Generic;

namespace FileSystemLib
{
    public class InMemoryDirectory : IInMemoryFile
    {
        public InMemoryFileType FileType => InMemoryFileType.Directory;
        public InMemoryDirectory Parent { get; set; }
        public List<IInMemoryFile> Children { get; set; } = new List<IInMemoryFile>();
        public string Name { get; set; }
        public string Path
        {
            get
            {
                string path;
                if (Parent == null)
                {
                    path = "/";
                }
                else
                {
                    path = Parent.Path != "/" ? $"{Parent.Path}/{Name}" : $"/{Name}";
                }
                return path;
            }
        }

        public InMemoryDirectory(string name, InMemoryDirectory parentDirectory)
        {
            Name = name;
            Parent = parentDirectory;

            if (parentDirectory != null)
            {
                parentDirectory.Children.Add(this);
            }
        }

        /// <summary>
        /// Root only
        /// </summary>
        /// <param name="name"></param>
        public InMemoryDirectory()
        {
            Name = "/";
            Parent = null;
        }      
    }
}
