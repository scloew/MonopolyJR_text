using System;

namespace MonopolyJR_text
{
    class MonopolyProperty : MonopolySquare
    {
        private int rent { get; set; }
        private Player owner { get; set; }
        private MonopolyProperty neighbor { get; set; }

        delegate void actionDelegate(Player p);
        private actionDelegate ad; //should change name to action

        delegate void printDelegate(Player p);
        private printDelegate pd; //should change name to print
        //TODO use lambdas to set login of delegates


        public MonopolyProperty(string name, int rent) : base(name)
        {
            this.rent = rent;
            this.ad = firstAction;
            this.pd = printPurchaseMessage;
        }

        public void setNeighbor(MonopolyProperty mp)
        {
            neighbor = mp;
        }

        public void setMonop()
        {
            rent *= 2;
        }

        public Player getOwner()
        {
            return owner;
        }

        private void subsequentActions(Player p)
        {
            owner.addMoney(rent);
            p.addMoney(-1 * rent);
        }

        public void firstAction(Player p)
        {
            owner = p;
            p.addMoney(-1 * rent);

            if (neighbor.getOwner() == p)
            {
                setMonop();
                neighbor.setMonop();
            }

            ad = subsequentActions;
            pd = printInteraction;
        }

        public override void action(Player p)
        {
            printActionMessage(p);
            ad(p);
        }

        private void printPurchaseMessage(Player p)
        {
            Console.WriteLine(p.getName() + " pays $" + rent.ToString() + " to purchase " + name);
            pd = printInteraction;
        }

        private void printInteraction(Player p)
        {
            Console.WriteLine(p.getName() + " pays " + owner.getName() + " $" + rent);
        }

        protected override void printActionMessage(Player p)
        {
            pd(p);
        }
    }
}
