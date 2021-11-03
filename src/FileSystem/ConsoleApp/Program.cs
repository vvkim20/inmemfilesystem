using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryDirectory root = new InMemoryDirectory("root", null);
            var current = root;
            while (true)
            {
                Console.Write(">");
                var userInput = Console.ReadLine();

                MakeFile(userInput, current);

                Console.WriteLine($">> {GetFiles(current)}");
            }
        }

        private static string GetFiles(InMemoryDirectory current)
        {
            return string.Join(", ", current.Children.Select(c => c.Name).ToList());
        }

        private static  void MakeDirectory(string name, InMemoryDirectory current)
        {
            // Verify there is no directory with the same name
            if (current.Children.Any(c => c.FileType == FileType.Directory && c.Name == name))
                throw new ArgumentException($"{name} directory already exist");

            // Create a new directory
            _ = new InMemoryDirectory(name, current);
        }

        private static void MakeFile(string name, InMemoryDirectory current)
        {
            // Verify there is no directory with the same name
            if (current.Children.Any(c => c.FileType == FileType.File && c.Name == name))
                throw new ArgumentException($"{name} file already exist");

            //  Create a new file
            _ = new InMemoryFile(name, current);
        }
    }

    public interface IInMemoryFile
    {
        FileType FileType { get; }
        InMemoryDirectory Parent { get; set; }
        string Name { get; }
    }
    public enum FileType
    {
        Directory,
        File
    }

    public class InMemoryDirectory : IInMemoryFile
    {
        public FileType FileType => FileType.Directory;
        public InMemoryDirectory Parent { get; set; }
        public List<IInMemoryFile> Children { get; set; } = new List<IInMemoryFile>();
        public string Name { get; }

        public InMemoryDirectory(string name, InMemoryDirectory parentDirectory)
        {
            Name = name;
            Parent = parentDirectory;
            if (parentDirectory != null)
            { 
                parentDirectory.Children.Add(this); 
            }
        }
    }

    public class InMemoryFile : IInMemoryFile
    {
        public FileType FileType => FileType.File;
        public InMemoryDirectory Parent { get; set; }
        public string Name { get; }
        public string Contents { get; set; }

        public InMemoryFile(string name, InMemoryDirectory parentDirectory)
        {
            Name = name;
            Parent = parentDirectory;
            parentDirectory.Children.Add(this);
        }
    }
}
