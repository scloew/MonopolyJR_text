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
            printActionMessage(p);
            p.move();
        }

        protected override void printActionMessage(Player p)
        {
            Console.WriteLine(p.getName() + " rides " + name + " and rolls again");
        }
    }
}
