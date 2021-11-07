using FileSystemLib;
using FileSystemLib.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FileSystemLibTests.Commands
{
    [TestClass]
    public class MoveAndCopyCommandTests
    {
        [TestMethod]
        public void CopyTests()
        {
            // Arrange
            // root -> a -> aa -> bFile
            //                 -> aaa -> aaaa
            //           -> ab
            InMemoryDirectory currentDirectory = new InMemoryDirectory();
            InMemoryDirectory aDirectory = new InMemoryDirectory("a", currentDirectory);
            InMemoryDirectory aaDirectory = new InMemoryDirectory("aa", aDirectory);
            InMemoryFile bFile = new InMemoryFile("bFile", aaDirectory);
            InMemoryDirectory aaaDirectory = new InMemoryDirectory("aaa", aaDirectory);
            InMemoryDirectory aaaaDirectory = new InMemoryDirectory("aaaa", aaaDirectory);
            InMemoryDirectory abDirectory = new InMemoryDirectory("ab", aDirectory);


            // Act
            // Copy aa to b
            var copycommand = new MoveAndCopyCommand();
            copycommand.Execute("copy file aa ab", aDirectory);

            // Assert
            // Assert Directories
            // root -> a -> aa -> bFile
            //                 -> aaa
            //           -> ab -> aa -> bFile
            //                       -> aaa
            AssertDirectories(aaDirectory, (InMemoryDirectory)abDirectory.Children.Single(c => c.Name == "aa"));
        }

        private void AssertDirectories(InMemoryDirectory expected, InMemoryDirectory actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Children.Count, actual.Children.Count);
            foreach (var child in expected.Children)
            {
                var actualChild = actual.Children.Single(c => c.Name == child.Name && c.FileType == child.FileType);
                if (child.FileType == FileSystemLib.Enums.InMemoryFileType.Directory)
                {
                    AssertDirectories((InMemoryDirectory)child, (InMemoryDirectory)actualChild);
                }else
                {
                    AssertFiles((InMemoryFile)child, (InMemoryFile)actualChild);
                }
            }

        }
        private void AssertFiles(InMemoryFile expected, InMemoryFile actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Contents, actual.Contents);
        }
    }
}
