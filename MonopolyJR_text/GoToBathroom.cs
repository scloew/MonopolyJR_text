using System;

namespace MonopolyJR_text
{
    class GoToBathroom : TaxSquare
    {
        public GoToBathroom(string name, int tax, LooseChange lc) : base(name, tax, lc)
        {

        }

        public override void action(Player p)
        {
            base.action(p);
            printActionMessage(p);
            p.setLocation(10);
        }

        protected override void printActionMessage(Player p)
        {
            Console.WriteLine($"{p.getName()} goes straight to bathroom");
        }
    }
}
