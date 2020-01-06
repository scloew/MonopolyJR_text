using System;

namespace MonopolyJR_text
{

    class ChanceSquare : MonopolySquare
    {

        private Random RNG;
        private int ChanceAffect;

        delegate void printDelegate(string playerName);
        private printDelegate pd;

        public ChanceSquare(string name) : base(name)
        {
            RNG = new Random();
        }

        public override void action(Player p)
        {
            int action = RNG.Next(1, 2);

            if (action == 1) //add money
            {
                ChanceAffect = RNG.Next(-5, 6);
                p.addMoney(ChanceAffect);
                pd = printAddMon;
            }
            else //else move
            {
                ChanceAffect = RNG.Next(0, 31);
                p.setLocation(ChanceAffect);
                pd = printMove;
            }

            PrintActionMessage(p.Name);
        }

        private void printAddMon(string playerName)
        {
            Console.WriteLine("Chance adds $" + ChanceAffect.ToString() + " to " + playerName);
        }

        private void printMove(string playerName)
        {
            Console.WriteLine("Chance moves " + playerName + " to square " + ChanceAffect.ToString());
        }

        protected override void PrintActionMessage(string playerName)
        {
            pd(playerName);
        }
    }
}
