using System;

namespace MonopolyJR_text
{

    class ChanceSquare : MonopolySquare
    {

        private Random r;
        private int chanceAffect;

        delegate void printDelegate(string playerName);
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

            PrintActionMessage(p.getName());
        }

        private void printAddMon(string playerName)
        {
            Console.WriteLine("Chance adds $" + chanceAffect.ToString() + " to " + playerName);
        }

        private void printMove(string playerName)
        {
            Console.WriteLine("Chance moves " + playerName + " to square " + chanceAffect.ToString());
        }

        protected override void PrintActionMessage(string playerName)
        {
            pd(playerName);
        }
    }
}
