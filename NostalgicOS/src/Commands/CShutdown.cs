using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace NostalgicOS.Commands
{
    public class CShutdown : Command
    {
        public CShutdown() : base("shutdown", "Shutdowns PC. Use -r to reboot instead.")
        {
        }

        public override void Execute(string[] m_Args)
        {
            if (m_Args.ToList().Exists(arg => arg == "-r"))
            {
                Console.WriteLine("Rebooting PC...");
                Sys.Power.Reboot();
            }
            else
            {
                Console.WriteLine("Shutting Down PC...");
                Sys.Power.Shutdown();
            }
        }
    }
}
