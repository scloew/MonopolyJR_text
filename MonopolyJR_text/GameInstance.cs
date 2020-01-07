using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyJR_text
{
    class GameInstance
    /*
   Should have interface for playGame, takeTurn, printResults to make project more reusable, 
   but also kinda overkill  
   */
  {
        List<Player> Players;
        private MonopolySquare[] Board;
        private bool EndGame;

        public GameInstance(String[] players, MonopolySquare[] board)
        {
            Players = new List<Player>();
            foreach(string name in players) {
               Players.Add(new Player(name));
               System.Threading.Thread.Sleep(500); //force sleep to ensure better seeding
            } //TODO is there a way to do this with LINQ?
            Board = board;
            EndGame = false;

            playGame();
        }


        private void print(int winScore, bool findLosers, string message)
        //findLosers = 1 to print losers, 0 to find winners
        {
            foreach (Player p in Players)
            {
                if ((p.Money == winScore) ^ findLosers)
                {
                    Console.WriteLine($"With ${p.Money} {p.Name} {message}");
                }
            }
        }

        private int getWinnerScore()
        //Returns the maximum score of any players
        {
            int winSum = 0;
            foreach (Player p in Players)
            {
                winSum = Math.Max(winSum, p.Money);
            }
            return winSum;
        }

        private void printResults()
        {
            int winScore = getWinnerScore();

            Console.WriteLine("\n*******\nWinners\n*******\n");
            print(winScore, false, "wins the game!!!!!");
            Console.WriteLine("*******\nLosers\n*******\n");
            print(winScore, true, "loses the game :(");
        }

        private void takeTurn(Player activePlayer)
        {
            int origLoc = activePlayer.Location;
            activePlayer.move();
            int loc;
            do
            {
                loc = activePlayer.Location;
                Console.WriteLine($"{activePlayer.Name} moves to {Board[loc].Name}");
                Board[activePlayer.Location].Action(activePlayer);
            } while (loc != activePlayer.Location && !activePlayer.isBankRupt());
            if (loc < origLoc)
            {
              Console.WriteLine($"{activePlayer.Name} passes Go and collects {Constants.PassGoBonues }");
              activePlayer.addMoney(Constants.PassGoBonues);
            }
    }

        private void printTurnIndex(int TurnIndex)
        {
            Console.WriteLine($"========\n Turn: {TurnIndex} \n========\n");
            foreach (Player p in Players)
            {
                Console.WriteLine($"{p.Name} has ${p.Money} and is at square {p.Location} => {Board[p.Location].Name}");
            }
        }

        private void turn()
        {
            for (int i = 0; i < Players.Count && !EndGame; i++)
            {
                takeTurn(Players[i]);
                EndGame = Players[i].isBankRupt();
            }
        }

        private void playGame()
        {
            Player activePlayer = Players[0];
            int turnCounter = 1;
 
            do
            {
                printTurnIndex(turnCounter);
                turn();
                turnCounter += 1;
            } while (!EndGame && turnCounter < Constants.TurnLimit);

            printResults();

        }
    }
}
