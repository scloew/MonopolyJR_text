using System;

namespace MonopolyJR_text
{
    class MonopolyProperty : MonopolySquare
    {
        public int Rent { get; set; }
        public Player Owner { get; set; }
        public MonopolyProperty Neighbor { get; set; } //need to resolve this ciruclar reference

        delegate void actionDelegate(Player p);
        private actionDelegate ad; //should change name to action

        delegate void printDelegate(string p);
        private printDelegate pd; //should change name to print
        //TODO use lambdas to set login of delegates


        public MonopolyProperty(string name, int rent) : base(name)
        {
            this.Rent = rent;
            this.ad = firstAction;
            this.pd = printPurchaseMessage;
        }

        public void setMonop()
        {
            Rent *= 2;
        }

        private void subsequentActions(Player p)
        {
            Owner.addMoney(Rent);
            p.addMoney(-1 * Rent);
        }

        public void firstAction(Player p)
        {
            Owner = p;
            p.addMoney(-1 * Rent);

            if (Neighbor.Owner == p)
            {
                setMonop();
                Neighbor.setMonop();
            } //TODO fix circular reference

            ad = subsequentActions;
            pd = printInteraction;
        }

        public override void action(Player p)
        {
            PrintActionMessage(p.Name);
            ad(p);
        }

        private void printPurchaseMessage(string playerName)
        {
            Console.WriteLine(playerName + " pays $" + Rent.ToString() + " to purchase " + Name);
            pd = printInteraction;
        }

        private void printInteraction(string playerName)
        {
            Console.WriteLine(playerName + " pays " + Owner.Name + " $" + Rent);
        }

        protected override void PrintActionMessage(string playerName)
        {
            pd(playerName);
        }
    }
}
