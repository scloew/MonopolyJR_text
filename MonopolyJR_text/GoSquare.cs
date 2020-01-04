using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyJR_text
{
    class GoSquare : MonopolySquare
    {
        public GoSquare(string name) : base(name)
        {

        }

        public override void action(Player p)
        {
            p.addMoney(3);
        }

        protected override void printActionMessage(Player p)
        {
            Console.WriteLine(p.getName() + " collects $3 landing passing go");
        }
    }
}
