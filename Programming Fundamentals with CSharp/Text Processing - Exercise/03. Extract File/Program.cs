using System;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int extensionFirstIndex = path.LastIndexOf('.') + 1;
            int extensionCountSymbols = path.Length - extensionFirstIndex;
            int fileStartIndex = path.LastIndexOf('\\') + 1;
            int fileCountSymbols = extensionFirstIndex - fileStartIndex - 1;
            Console.WriteLine($"File name: {path.Substring(fileStartIndex, fileCountSymbols)}");
            Console.WriteLine($"File extension: {path.Substring(extensionFirstIndex, extensionCountSymbols)}");

        }
    }
}
