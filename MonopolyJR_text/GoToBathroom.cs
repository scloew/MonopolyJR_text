using System;

namespace MonopolyJR_text
{
    class GoToBathroom : TaxSquare
    {
       private int SquareLocation;

        public GoToBathroom(string name, int tax, LooseChange lc, int squareLocation) : base(name, tax, lc)
        {
           SquareLocation = squareLocation;
        }

        public override void Action(Player p)
        {
            base.Action(p);
            PrintActionMessage(p.Name);
            p.Location = SquareLocation; //TODO magic number
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} goes straight to bathroom");
        }
    }
}
