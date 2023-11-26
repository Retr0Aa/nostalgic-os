using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using NostalgicOS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys = Cosmos.System;
using System.IO;

namespace NostalgicOS
{
    public class Kernel : Sys.Kernel
    {
        CommandManager commandManager;

        protected override void BeforeRun()
        {
            var fs = new CosmosVFS();
            VFSManager.RegisterVFS(fs);

            commandManager = new CommandManager();
            commandManager.RegisterCommand(new CHelp(commandManager));
            commandManager.RegisterCommand(new CShutdown());
            commandManager.RegisterCommand(new CFiles(fs));
            commandManager.RegisterCommand(new CClear());
            commandManager.RegisterCommand(new CCD());

            var availableSpace = fs.GetAvailableFreeSpace(@"0:\");
            Console.WriteLine("Available Free Space: " + availableSpace);
            Directory.SetCurrentDirectory(@"0:\");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("NostalgicOS booted successfully!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void Run()
        {
            Console.Write($"{Directory.GetCurrentDirectory()}| ");
            
            try
            {
                string[] input = Console.ReadLine().Split(" ");
                string[] args = input.Skip(1).ToArray();
                commandManager.ExecuteCommand(input[0], args);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
