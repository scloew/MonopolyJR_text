using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyJR_text
{
    class GameInstance
    //Should have interface for playGame, takeTurn, printResults
    {
        private Player[] Players;
        private MonopolySquare[] Board;
        private bool EndGame;


        public GameInstance(Player[] players, MonopolySquare[] board)
        {
            Players = players;
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
            int origLoc = activePlayer.getLocation();
            activePlayer.move();
            int loc;
            do
            {
                loc = activePlayer.getLocation();
                Console.WriteLine($"{activePlayer.Name} moves to {Board[loc].Name}");
                Board[activePlayer.getLocation()].action(activePlayer);
            } while (loc != activePlayer.getLocation() && !activePlayer.isBankRupt());
            if (loc < origLoc)
            {
              Console.WriteLine($"{activePlayer.Name} passes Go and collects {Constants.PassGoBonues }");
              activePlayer.addMoney(3);
            }
    }

        private void printTurnIndex(int TurnIndex)
        {
            Console.WriteLine($"========\n Turn: {TurnIndex} \n========\n");
            foreach (Player p in Players)
            {
                Console.WriteLine($"{p.Name} has {p.Name}");
            }
        }

        private void turn()
        {
            for (int i = 0; i < Players.Length && !EndGame; i++)
            {
                takeTurn(Players[i]);
                EndGame = Players[i].isBankRupt();
            }
        }

        private void playGame()
        {
            Player activePlayer = Players[0];
            int turnCounter = 1;

            //Game can last max of 100 turns
            //Ends as soon as any player is bankrupt
            do
            {
                printTurnIndex(turnCounter);
                turn();
                turnCounter += 1;
            } while (!EndGame && turnCounter < 100);

            printResults();

        }
    }
}
