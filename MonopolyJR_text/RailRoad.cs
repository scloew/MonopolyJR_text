using System;

namespace MonopolyJR_text
{
    class RailRoad : MonopolySquare
    {

        public RailRoad(string name) : base(name)
        {
        }

        public override void action(Player p)
        {
            PrintActionMessage(p.getName());
            p.move();
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} rides {name} and rolls agains");
        }
    }
}
