using System;
using System.IO;
using System.Linq;
using Spectre.Console;

namespace SpectreTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args != null && args.Length > 0 ? args[0] : ".";
            foreach (var directory in Directory.GetDirectories(path))
            {
                PrintDirectory(directory);
                foreach (var file in Directory.GetFiles(directory)) PrintFile(file);
            }
            foreach (var file in Directory.GetFiles(path)) PrintFile(file);
            Console.ReadKey();
        }

        static void PrintFile(string file)
        {
            AnsiConsole.MarkupLine($"[underline red]{file}[/]");
        }

        static void PrintDirectory(string directory)
        {
            AnsiConsole.MarkupLine($"[underline green]{directory}[/]");
        }
    }
}
