using System;

namespace MonopolyJR_text
{
    class TaxSquare : MonopolySquare
    {
        protected int Tax;
        private LooseChange Lc; //TODO do I want square to have all LC or just addmoney method


        public TaxSquare(string name, int tax, LooseChange lc) : base(name)
        {
            Tax = tax;
            Lc = lc;
        }

        public override void Action(Player p)
        {
            PrintActionMessage(p.Name);
            p.addMoney(-1 * Tax);
            Lc.addMoney(Tax);
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} pays {Tax} to loose change jar for landing on {Name}");
        }
    }
}
