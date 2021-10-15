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
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    var path = o.Path;
                    var tree = PrintFileSystemEntries(path);
                    AnsiConsole.Write(tree);
                })
            ;
            Console.ReadKey();
        }

        static Tree PrintFileSystemEntries(string path)
        {
            var tree = new Tree("");
            foreach (var directory in Directory.EnumerateDirectories(path).Select(d => new DirectoryInfo(d)))
            {
                tree.AddNode(GetDirectoryMarkup(directory.Name));
                tree.AddNode(PrintFileSystemEntries(directory.FullName));
            }

            foreach (var file in Directory.EnumerateFiles(path).Select(f => new FileInfo(f)))
            {
                tree.AddNode(GetFileMarkup(file.Name));
            }

            return tree;
        }

        static string GetFileMarkup(string file)
        {
            return $"[red]{file}[/]";
        }

        static string GetDirectoryMarkup(string directory)
        {
            return $"[green]{directory}[/]";
        }
    }
}
