using FileSystemLib;
using FileSystemLib.Commands;
using FileSystemLib.Enums;
using FileSystemLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryDirectory root = new InMemoryDirectory();
            var current = root;
            var commands = new FileCommands();
            while (true)
            {
                Console.Write("> ");
                var userInput = Console.ReadLine();
                string outputMessage = "";
                try
                {
                    current = commands.ExecuteCommand(userInput, current);
                }
                catch (FileSystemException applicationException)
                {
                    outputMessage = applicationException.Message;
                }
                catch (Exception exception)
                {
                    // need a error message convert
                    outputMessage = exception.Message;
                }
                finally
                {
                    if(!string.IsNullOrWhiteSpace(outputMessage))
                        Console.WriteLine($">> {outputMessage}");
                }
            }
        }
    }
}
