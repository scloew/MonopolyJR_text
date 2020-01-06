using System;

namespace MonopolyJR_text
{
    class Bathroom : MonopolySquare
    {
        public Bathroom(string name) : base(name) { }
        
        public override void action(Player p)
        {
            PrintActionMessage(p.Name);
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} lands on bathroom");
        }
    }
}
