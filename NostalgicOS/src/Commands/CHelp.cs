using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicOS.Commands
{
    public class CHelp : Command
    {
        private CommandManager _commandManager;

        public CHelp(CommandManager commandManager) : base("help", "Show all avaliable commands.")
        {
            _commandManager = commandManager;
        }

        public override void Execute(string[] m_Args)
        {
            Console.WriteLine("Commands Installed On This PC:");
            
            foreach (Command cmd in _commandManager.GetCommands())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"\t{cmd.GetName()}:  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{cmd.GetDescription()}");
            }
        }
    }
}
