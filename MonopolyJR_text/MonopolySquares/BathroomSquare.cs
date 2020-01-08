using System;

namespace MonopolyJR_text
{
    class BathroomSquare : MonopolySquare
    {
        public BathroomSquare(string name) : base(name) { }
        
        public override void Action(Player p)
        {
            PrintActionMessage(p.Name);
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} lands on bathroom");
        }
    }
}
