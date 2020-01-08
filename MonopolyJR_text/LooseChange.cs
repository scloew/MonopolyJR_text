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

        public override void Action(Player p)
        {
            PrintActionMessage(p.Name);
            p.AddMoney(MoneyPot);
            MoneyPot = 0;
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} collects ${MoneyPot} from loose change jar");
        }

        public void AddMoney(int n)
        {
            MoneyPot += n;
        }
    }
}
