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

        public override void Action(Player p)
        {
            int action = RNG.Next(1, 2);

            if (action == 1) //add money
            {
                ChanceAffect = RNG.Next(-5, 6);
                p.addMoney(ChanceAffect);
                pd = name => {Console.WriteLine($"Chance adds ${ChanceAffect} to {name}"); };
            }
            else //else move
            {
                ChanceAffect = RNG.Next(0, 31);
                //p.setLocation(ChanceAffect);
                p.Location = ChanceAffect;
                pd = name => { Console.WriteLine($"Chance moves anme to {ChanceAffect}"); };
      }

            PrintActionMessage(p.Name);
        }

        protected override void PrintActionMessage(string playerName)
        {
            pd(playerName);
        }
    }
}
