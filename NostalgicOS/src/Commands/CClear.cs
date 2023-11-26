using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace NostalgicOS.Commands
{
    public class CClear : Command
    {
        public CClear() : base("clear", "Clear console.")
        {
        }

        public override void Execute(string[] m_Args)
        {
            Console.Clear();
        }
    }
}
