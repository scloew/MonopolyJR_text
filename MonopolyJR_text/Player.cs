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

        //public int getLocation()
        //{
        //    return Location;
        //}

        //public void setLocation(int n)
        //{
        //    Location = n % 32;
        //    //Ideally the board size (32) would not be hard coded
        //}

        public void move()
        {
            int roll = RNG.Next(1, 7);
            //setLocation(Location + roll);
            this.Location=Location+roll;
            Console.WriteLine($"{Name} rolls {roll}");
        }
    }
}
