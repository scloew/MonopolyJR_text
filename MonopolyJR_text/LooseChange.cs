using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyJR_text
{
    class LooseChange : MonopolySquare
    {
        private int moneyPot;

        public LooseChange(string name) : base(name)
        {
            this.moneyPot = 0;
        }

        public override void action(Player p)
        {
            PrintActionMessage(p.getName());
            p.addMoney(moneyPot);
            moneyPot = 0;
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} collects ${moneyPot} from loose change jar");

        }

        public void addMoney(int n)
        {
            moneyPot += n;
        }
    }
}
