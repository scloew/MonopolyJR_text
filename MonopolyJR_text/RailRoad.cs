using System;

namespace MonopolyJR_text
{
    class RailRoad : MonopolySquare
    {

        public RailRoad(string name) : base(name)
        {
        }

        public override void Action(Player p)
        {
            PrintActionMessage(p.Name);
            p.Move();
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} rides {Name} and rolls agains");
        }
    }
}
