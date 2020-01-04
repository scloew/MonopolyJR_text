using System;

namespace MonopolyJR_text
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Setting up board...\n\n");

            Player[] players = new Player[2];
            players[0] = new Player("Rockefeller");
            System.Threading.Thread.Sleep(5000);
            //timer to ensure better seeding of Player's rng
            players[1] = new Player("Carnegie");

            MonopolySquare[] board = new MonopolySquare[32];
            BoardBuilder.buildBoard(board);
            foreach (Player p in players)
            {
                Console.Write(p.getInfo());
            }
            GameInstance game = new GameInstance(players, board);

            Console.WriteLine("Enter enter key to begin new game");

            Console.ReadKey();

            Player[] newPlayers = { players[0], players[1], new Player("Charles Montgomery Burns") };
            foreach (Player p in newPlayers)
            {
                Console.Write(p.getInfo());
            } //should game instance create players? -> probably
            
            players[0] = new Player("Rockefeller");
            System.Threading.Thread.Sleep(5000);
            //timer to ensure better seeding of Player's rng
            players[1] = new Player("Carnegie");
            GameInstance game2 = new GameInstance(newPlayers, board);

            Console.ReadKey();
        }
    }
}
