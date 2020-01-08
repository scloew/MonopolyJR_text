using System;

namespace MonopolyJR_text
{
    class PropertySquare : MonopolySquare
    {
        private int Rent;
        public Player Owner { get; set; }

        delegate void actionDelegate(Player p);
        private actionDelegate ActionDel; 

        delegate void printDelegate(string p);
        private printDelegate Print;

        delegate void MonopolyChecker();
        private MonopolyChecker CheckMonopoly;


        public PropertySquare(string name, int rent) : base(name)
        {
            Rent = rent;
            CheckMonopoly = () => { throw new Exception("CheckMonopoly never properly set"); };
            ActionDel = player => 
            {
              Owner = player;
              player.AddMoney(-1 * Rent);
              CheckMonopoly();
            };
            Print = playerName => { Console.WriteLine($"{playerName} pays ${Rent} to purchase {Name}"); };
        }

        public void SetCheckMonopoly(PropertyPair monopoly)
        {
          CheckMonopoly = monopoly.CheckMonopoly;
        }

        public void SetMonopoly()
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
