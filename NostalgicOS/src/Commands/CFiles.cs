using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace NostalgicOS.Commands
{
    public class CFiles : Command
    {
        private CosmosVFS fs;

        public CFiles(CosmosVFS fs) : base("files", "Perform file system operation. Arguments:\n" +
            "\t\t-space: Show the free space on drive.\n" +
            "\t\t-crdir [fileName]: Creates new directory in current directory.\n" +
            "\t\t-ls: Shows all files in the current directory.")
        {
            this.fs = fs;
        }

        public override void Execute(string[] m_Args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            if (m_Args.Length > 0)
            {
                switch (m_Args[0])
                {
                    case "-space":
                        var available_space = fs.GetAvailableFreeSpace(@"0:\");
                        Console.WriteLine("Available Free Space: " + available_space);
                    
                        break;
                    case "-crdir":
                        if (m_Args.Length > 1)
                        {
                            string newDirPath = $@"{Directory.GetCurrentDirectory()}\{m_Args[1]}";
                            if (!Directory.Exists(newDirPath))
                            {
                                try
                                {
                                    Directory.CreateDirectory(newDirPath);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString());
                                }

                                Console.WriteLine($"Directory '{m_Args[1]}' created successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Directory '{m_Args[1]}' already exists.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Usage: -crdir [directoryName]");
                        }
                        break;
                    case "-ls":
                        var files_list = Directory.GetFiles(Directory.GetCurrentDirectory());
                        var directory_list = Directory.GetDirectories(Directory.GetCurrentDirectory());

                        foreach (var file in files_list)
                        {
                            FileInfo fi = new FileInfo(file);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(Path.GetFileNameWithoutExtension(fi.Name));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($" | {fi.Extension} File");
                        }
                        foreach (var directory in directory_list)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(directory);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" | Directory");
                        }

                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No arguments provided! See help for more info.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
