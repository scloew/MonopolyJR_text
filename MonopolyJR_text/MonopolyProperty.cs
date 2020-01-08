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
              player.AddMoney(-1 * Rent);

              if (Neighbor.Owner == player)
              {
                SetMonop();
                Neighbor.SetMonop();
              } //TODO fix circular reference
            };

            Print = playerName => { Console.WriteLine($"{playerName} pays ${Rent} to purchase {Name}"); };
        }

        public void SetMonop()
        {
            Rent *= 2;
        }

        public override void Action(Player p)
        {
            PrintActionMessage(p.Name);
            ActionDel(p);
            ActionDel = player => { Owner.AddMoney(Rent); player.AddMoney(-1 * Rent); };
        }

        protected override void PrintActionMessage(string playerName)
        {
            Print(playerName);
            Print = name => { Console.WriteLine($"{name} pays {Owner.Name} ${Rent}"); };
        }
    }
}
