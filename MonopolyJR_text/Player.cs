using System;

namespace MonopolyJR_text
{
    class Player
    {
        public string Name { get; set; }
        public int Money { get; set; } //do I want setters

        private int _Location;
        public int Location { get { return _Location; } set { _Location = value % 32; } }
        private Random RNG;

        public Player(string name) //could overload this to allow for custom setting of starting money
        {
            Name = name;
            Money = Constants.StartingMoney;
            RNG = new Random();
        }

        public void AddMoney(int n)
        {
            Money += n;
        }

        public bool IsBankrupt()
        {
            return Money <= 0;
        }

        public string GetInfo()
        {
            return ($"{Name} {Money}\n");
        }

        public void Move()
        {
            int roll = RNG.Next(1, 7);
            Location=Location+roll;
            Console.WriteLine($"{Name} rolls {roll}");
        }
    }
}
