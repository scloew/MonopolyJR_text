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

        public override void Action(Player p)
        {
            p.addMoney(Constants.PassGoBonues);
            PrintActionMessage(p.Name);
        } //is this doubling up on pass go bonus

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} lands on go and collects additonal bonus of {Constants.PassGoBonues}");
        }
    }
}
