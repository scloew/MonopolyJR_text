using System;

namespace MonopolyJR_text
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Setting up board...\n\n");

            string[] players = {"Rockerfell", "Carnegie" };
            GameInstance game = new GameInstance(players);
           
            Console.WriteLine("Enter enter key to begin new game");
            Console.ReadKey();

            string[] newPlayers = { "Rockerfell", "Carnegie", "Charles Montgomery Burns" };
            GameInstance game2 = new GameInstance(newPlayers);

            Console.ReadKey();
        }
    }
}
