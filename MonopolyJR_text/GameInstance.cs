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
        Player[] players;
        MonopolySquare[] board;
        bool endGame;


        public GameInstance(Player[] players, MonopolySquare[] board)
        {
            this.players = players;
            this.board = board;
            this.endGame = false;

            playGame();
        }


        private void print(int winScore, bool findLosers, string message)
        //findLosers = 1 to print losers, 0 to find winners
        {
            foreach (Player p in players)
            {
                if ((p.getMoney() == winScore) ^ findLosers)
                {
                    Console.WriteLine($"With ${p.getMoney()} {p.getName()} {message}");
                }
            }
        }

        private int getWinnerScore()
        //Returns the maximum score of any players
        {
            int winSum = 0;
            foreach (Player p in players)
            {
                winSum = Math.Max(winSum, p.getMoney());
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
                Console.WriteLine($"{activePlayer.getName()} moves to {board[loc].getName()}");
                board[activePlayer.getLocation()].action(activePlayer);
            } while (loc != activePlayer.getLocation() && !activePlayer.isBankRupt());
            if (loc < origLoc)
            {
                Console.WriteLine($"{activePlayer.getName()} passes Go and collects {Constants.PassGoBonues }");
                activePlayer.addMoney(3);
            }
        }

        private void printTurnIndex(int TurnIndex)
        {
            Console.WriteLine($"========\n Turn: {TurnIndex} \n========\n");
            foreach (Player p in players)
            {
                Console.WriteLine($"{p.getName()} has {p.getMoney()}");
            }
        }

        private void turn()
        {
            for (int i = 0; i < players.Length && !endGame; i++)
            {
                takeTurn(players[i]);
                endGame = players[i].isBankRupt();
            }
        }

        private void playGame()
        {
            Player activePlayer = players[0];
            int turnCounter = 1;

            //Game can last max of 100 turns
            //Ends as soon as any player is bankrupt
            do
            {
                printTurnIndex(turnCounter);
                turn();
                turnCounter += 1;
            } while (!endGame && turnCounter < 100);

            printResults();

        }
    }
}
