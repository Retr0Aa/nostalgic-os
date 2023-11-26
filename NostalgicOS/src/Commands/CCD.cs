using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace NostalgicOS.Commands
{
    public class CCD : Command
    {
        public CCD() : base("cd", "Go to other directory. Arguments:\n" +
            "\t\t[directoryPath]: The directory to go to.\n")
        {
        }

        public override void Execute(string[] m_Args)
        {
            if (m_Args.Length > 0)
            {
                if (m_Args[0].StartsWith(@"0:\"))
                {
                    if (Directory.Exists(m_Args[0]))
                    {
                        Directory.SetCurrentDirectory(m_Args[0]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Directory {m_Args[0]} does not exist!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    if (Directory.Exists(Directory.GetCurrentDirectory() + m_Args[0]))
                    {
                        Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "\\" + m_Args[0]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Directory {Directory.GetCurrentDirectory() + m_Args[0]} does not exist!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            else
            {
                Console.WriteLine("Usage: cd [directoryPath]");
            }
        }
    }
}
