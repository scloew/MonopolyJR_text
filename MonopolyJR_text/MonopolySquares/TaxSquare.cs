using System;

namespace MonopolyJR_text
{
    class TaxSquare : MonopolySquare
    {
        protected int Tax;

        delegate void DepositToLooseChange(int money);
        private readonly DepositToLooseChange Deposit;


        public TaxSquare(string name, int tax, LooseChangeSquare lc) : base(name)
        {
            Tax = tax;
            Deposit = lc.AddMoney;
        }

        public override void Action(Player p)
        {
            PrintActionMessage(p.Name);
            p.AddMoney(-1 * Tax);
            Deposit(Tax);
        }

        protected override void PrintActionMessage(string playerName)
        {
            Console.WriteLine($"{playerName} pays {Tax} to loose change jar for landing on {Name}");
        }
    }
}
