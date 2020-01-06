using System;

namespace MonopolyJR_text
{
    class GoToBathroom : TaxSquare
    {
        public GoToBathroom(string name, int tax, LooseChange lc) : base(name, tax, lc)
        {

        }

        public override void Action(Player p)
        {
            base.Action(p);
            PrintActionMessage(p.Name);
            p.setLocation(10);
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} goes straight to bathroom");
        }
    }
}
