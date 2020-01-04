using System;

namespace MonopolyJR_text
{
    class Player
    {
        private string name { get; set; }
        private int money { get; set; } //do I want setters
        private int location { get; set; }
        private Random r;

        public Player(string name)
        {
            this.name = name;
            this.money = 31;
            this.r = new Random();
        }

        public int getMoney()
        {
            return money;
        }

        public string getName()
        {
            return name;
        }

        public void addMoney(int n)
        {
            money += n;
        }

        public bool isBankRupt()
        {
            return this.money <= 0;
        }

        public string getInfo()
        {
            return (name + " " + money + "\n");
        }

        public int getLocation()
        {
            return location;
        }

        public void setLocation(int n)
        {
            location = n % 32;
            //Ideally the board size (32) would not be hard coded
        }

        public void move()
        {
            int roll = r.Next(1, 7);
            setLocation(location + roll);
            Console.WriteLine(name + " rolls " + roll);
        }
    }
}
