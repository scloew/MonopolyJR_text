using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyJR_text
{
    abstract class MonopolySquare
    {
        protected string name { get; }

        public MonopolySquare(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public abstract void action(Player p);

        protected abstract void printActionMessage(Player p); //TODO make this take string (p.getName()) not whole player
    }
}
