using System;

namespace MonopolyJR_text
{
    class Player
    {
        public string Name { get; set; }
        public int Money { get; set; } //do I want setters
        public int Location { get; set; }
        private Random RNG;

        public Player(string name)
        {
            Name = name;
            Money = 31;
            RNG = new Random();
        }

        public void addMoney(int n)
        {
            Money += n;
        }

        public bool isBankRupt()
        {
            return Money <= 0;
        }

        public string getInfo()
        {
            return ($"{Name} {Money}\n");
        }

        public int getLocation()
        {
            return Location;
        }

        public void setLocation(int n)
        {
            Location = n % 32;
            //Ideally the board size (32) would not be hard coded
        }

        public void move()
        {
            int roll = RNG.Next(1, 7);
            setLocation(Location + roll);
            Console.WriteLine($"{Name} rolls {roll}");
        }
    }
}
