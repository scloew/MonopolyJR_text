using System;

namespace MonopolyJR_text
{
    class TaxSquare : MonopolySquare
    {
        protected int tax;
        private LooseChange lc;


        public TaxSquare(string name, int tax, LooseChange lc) : base(name)
        {
            this.tax = tax;
            this.lc = lc;
        }

        public override void action(Player p)
        {
            PrintActionMessage(p.getName());
            p.addMoney(-1 * tax);
            lc.addMoney(tax);
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} pays {tax} to loose change jar for landing on {name}");
        }
    }
}
