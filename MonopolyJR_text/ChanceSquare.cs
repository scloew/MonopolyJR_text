using System;

namespace MonopolyJR_text
{

    class ChanceSquare : MonopolySquare
    {

        private Random r;
        private int chanceAffect;

        delegate void printDelegate(Player p);
        private printDelegate pd;

        public ChanceSquare(string name) : base(name)
        {
            this.r = new Random();
        }

        public override void action(Player p)
        {
            int action = r.Next(1, 2);

            if (action == 1) //add money
            {
                chanceAffect = r.Next(-5, 6);
                p.addMoney(chanceAffect);
                pd = printAddMon;
            }
            else //else move
            {
                chanceAffect = r.Next(0, 31);
                p.setLocation(chanceAffect);
                pd = printMove;
            }

            printActionMessage(p);
        }

        private void printAddMon(Player p)
        {
            Console.WriteLine("Chance adds $" + chanceAffect.ToString() + " to " + p.getName());
        }

        private void printMove(Player p)
        {
            Console.WriteLine("Chance moves " + p.getName() + " to square " + chanceAffect.ToString());
        }

        protected override void printActionMessage(Player p)
        {
            pd(p);
        }
    }
}
