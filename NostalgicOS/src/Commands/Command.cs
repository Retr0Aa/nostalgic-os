using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicOS.Commands
{
    public abstract class Command
    {
        protected string m_Name;
        protected string m_Description;

        protected Command(string m_Name, string description)
        {
            this.m_Name = m_Name;
            m_Description = description;
        }

        public abstract void Execute(string[] m_Args);

        public string GetName() { return m_Name; }
        public string GetDescription() { return m_Description; }
    }
}
