using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyJR_text
{
    abstract class MonopolySquare
    {
        public string Name { get; }

        public MonopolySquare(string name)
        {
            Name = name;
        }

        public abstract void Action(Player p);

        protected abstract void PrintActionMessage(string playerName);
    }
}
