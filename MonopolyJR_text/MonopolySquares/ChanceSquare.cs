using System;

namespace MonopolyJR_text
{
    class ChanceSquare : MonopolySquare
    {

        private const int AddMoney = 1;
        private const int Move = 2;


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
            int action = RNG.Next(AddMoney, Move);

            if (action == AddMoney) //add money
            {
                ChanceAffect = RNG.Next(-5, 6);
                p.AddMoney(ChanceAffect);
                pd = name => {Console.WriteLine($"Chance adds ${ChanceAffect} to {name}"); };
            }
            else //else move
            {
                //TODO This shouldn't be hard coded; if board size isn't 32 will cause error
                ChanceAffect = RNG.Next(0, 31); 
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
