using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicOS.Commands
{
    public class CommandManager
    {
        private List<Command> commands;

        public CommandManager()
        {
            commands = new List<Command>();
        }

        public void RegisterCommand(Command command)
        {
            commands.Add(command);
        }

        public void ExecuteCommand(string commandName, string[] args)
        {
            if (commandName != "")
            {
                if (commands.Exists(x => x.GetName() == commandName))
                {
                    commands.Find(x => x.GetName() == commandName).Execute(args);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Command \"{commandName}\" not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public List<Command> GetCommands() { return commands; }
    }
}
