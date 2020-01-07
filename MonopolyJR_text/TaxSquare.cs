using System;

namespace MonopolyJR_text
{
    class TaxSquare : MonopolySquare
    {
        protected int Tax;

        delegate void DepositToLooseChange(int money);
        private DepositToLooseChange Deposit;


        public TaxSquare(string name, int tax, LooseChange lc) : base(name)
        {
            Tax = tax;
            Deposit = lc.addMoney;
        }

        public override void Action(Player p)
        {
            PrintActionMessage(p.Name);
            p.addMoney(-1 * Tax);
            Deposit(Tax);
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} pays {Tax} to loose change jar for landing on {Name}");
        }
    }
}
