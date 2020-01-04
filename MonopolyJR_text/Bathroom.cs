using System;

namespace MonopolyJR_text
{
    class Bathroom : MonopolySquare
    {
        public Bathroom(string name) : base(name)
        {

        }

        public override void action(Player p)
        {
            printActionMessage(p);
        }

        protected override void printActionMessage(Player p)
        {
            Console.WriteLine(p.getName() + " lands on bathroom");
        }
    }
}
