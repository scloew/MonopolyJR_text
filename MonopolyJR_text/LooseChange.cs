using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyJR_text
{
    class LooseChange : MonopolySquare
    {
        private int MoneyPot;

        public LooseChange(string name) : base(name)
        {
            MoneyPot = 0;
        }

        public override void action(Player p)
        {
            PrintActionMessage(p.Name);
            p.addMoney(MoneyPot);
            MoneyPot = 0;
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} collects ${MoneyPot} from loose change jar");

        }

        public void addMoney(int n)
        {
            MoneyPot += n;
        }
    }
}
