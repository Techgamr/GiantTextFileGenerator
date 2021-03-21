using System;
using System.IO;

namespace GiantTextFileGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Title = "GiantTextFileGenerator";
            
            Console.WriteLine("WARNING: This program can generate a giant file.\n" +
                              "Make sure that you have enough disk space available.\n" +
                              "If you want to continue, press C. Otherwise, press any other key to exit.");
            var kc = Console.ReadKey().KeyChar;
            if (kc != 'c' && kc != 'C') return;
            Console.Clear();
            Console.WriteLine("Welcome to GiantTextFileGenerator! Please input some options:\n");
            
            var size = GetFileSize();
            var fileName = GetFileName();
            var writeChar = GetWriteChar();
            Console.Write($"\nYour Choices:\n- File Size: {size} B\n- File Name: '{fileName}'\n- Write Char: '{writeChar}'\n" +
                          "Press enter to confirm and start writing bytes, or 'q' to quit: ");
            if (Console.ReadKey().KeyChar == 'q') return;
            Console.WriteLine("\n\nGenerating...");
            if (File.Exists(fileName)) File.Delete(fileName);
            GenerateStr(fileName, size, writeChar);
            
            Console.Write("\nFinished, press any key to exit... ");
            Console.ReadKey();
        }

        private static void GenerateStr(string path, ulong size, char writeChar)
        {
            using var writer = new StreamWriter(path, true);
            for (ulong i = 0; i < size; i++) writer.Write(writeChar);
            writer.Flush();
        }

        private static string GetFileName()
        {
            Console.Write("Output file name (giant.txt): ");
            var fileName = Console.ReadLine();
            if (string.IsNullOrEmpty(fileName)) fileName = "giant.txt";
            return fileName;
        }
        
        private static char GetWriteChar()
        {
            Console.Write("Character to write to file (A): ");
            var writeChar = Console.ReadLine();
            if (string.IsNullOrEmpty(writeChar) || writeChar.Length > 1) writeChar = "A";
            return writeChar.ToCharArray()[0];
        }

        private static ulong GetFileSize()
        {
            Console.Write("File size in MB (1024): ");
            var sizeStr = Console.ReadLine();
            if (string.IsNullOrEmpty(sizeStr)) sizeStr = "1024";
            return ulong.Parse(sizeStr) * 1000000;
        }
    }
}
