using System;
using System.IO;
using System.Linq;
using CommandLine;
using Spectre.Console;

namespace SpectreTree
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    var path = o.Path;
                    PrintFileSystemEntries(path);
                })
            ;
            Console.ReadKey();
        }

        static void PrintFileSystemEntries(string path, int depth = 0)
        {
            foreach (var directory in Directory.EnumerateDirectories(path).Select(d => new DirectoryInfo(d)))
            {
                if (depth > 0) PrintDepthSpacing(depth);

                PrintDirectory(directory.Name);
                PrintFileSystemEntries(directory.FullName, depth + 1);
            }

            foreach (var file in Directory.EnumerateFiles(path).Select(f => new FileInfo(f)))
            {
                PrintFile(file.Name, depth);
            }
        }

        private static void PrintDepthSpacing(int depth)
        {
            AnsiConsole.Write($"{new string(' ', (depth - 1) * 4)}└───");
        }

        static void PrintFile(string file, int depth = 0)
        {
            if (depth > 0) PrintDepthSpacing(depth);
            AnsiConsole.MarkupLine($"[red]{file}[/]");
        }

        static void PrintDirectory(string directory)
        {
            AnsiConsole.MarkupLine($"[green]{directory}[/]");
        }
    }
}
