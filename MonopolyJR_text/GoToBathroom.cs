using System;

namespace MonopolyJR_text
{
    class GoToBathroom : TaxSquare
    {
       private readonly int BathroomLocation;

        public GoToBathroom(string name, int tax, LooseChange lc, int bathroomLocation) : base(name, tax, lc)
        {
            BathroomLocation = bathroomLocation;
        }

        public override void Action(Player p)
        {
            base.Action(p);
            PrintActionMessage(p.Name);
            p.Location = BathroomLocation;
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} goes straight to bathroom");
        }
    }
}
