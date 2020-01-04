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
            printActionMessage(p);
            p.addMoney(-1 * tax);
            lc.addMoney(tax);
        }

        protected override void printActionMessage(Player p)
        {
            Console.WriteLine(p.getName() + " pays " + tax.ToString() + " to loose change jar for landing on " + name);
        }
    }
}
