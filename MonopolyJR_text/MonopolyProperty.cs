using System;

namespace MonopolyJR_text
{
    class MonopolyProperty : MonopolySquare
    {
        public int Rent { get; set; }
        public Player Owner { get; set; }
        public MonopolyProperty Neighbor { get; set; } //need to resolve this ciruclar reference

        delegate void actionDelegate(Player p);
        private actionDelegate ActionDel; 

        delegate void printDelegate(string p);
        private printDelegate Print;


        public MonopolyProperty(string name, int rent) : base(name)
        {
            Rent = rent;
            ActionDel = player => 
            {
              Owner = player;
              player.addMoney(-1 * Rent);

              if (Neighbor.Owner == player)
              {
                setMonop();
                Neighbor.setMonop();
              } //TODO fix circular reference
            };

            Print = playerName => { Console.WriteLine($"{playerName} pays ${Rent} to purchase {Name}"); };
        }

        public void setMonop()
        {
            Rent *= 2;
        }

        public override void Action(Player p)
        {
            PrintActionMessage(p.Name);
            ActionDel(p);
            ActionDel = player => { Owner.addMoney(Rent); player.addMoney(-1 * Rent); };
        }

        protected override void PrintActionMessage(string playerName)
        {
            Print(playerName);
            Print = name => { Console.WriteLine($"{name} pays {Owner.Name} #{Rent}"); };
        }
    }
}
