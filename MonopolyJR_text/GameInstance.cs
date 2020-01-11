using System;
using System.Collections.Generic;

namespace MonopolyJR_text
{
    class GameInstance
    /*
   Should have interface for playGame, takeTurn, printResults to make project more reusable, 
   but also kinda overkill for what I'm wanting to do with this
   */
  {
        List<Player> Players;
        private readonly List<MonopolySquare> Board;
        private bool EndGame;

        public GameInstance(String[] players, List<MonopolySquare> board = null)
        {
            if(board==null){
                board = BoardBuilder.BuildBoard();
            }
            Players = new List<Player>();
            foreach(string name in players) {
                Players.Add(new Player(name));
                System.Threading.Thread.Sleep(500); //force sleep to ensure better seeding
            }
            Board = board;
            EndGame = false;

            PlayGame();
        }

        private void PlayGame()
        {
            Player activePlayer = Players[0];
            int turnCounter = 1;
 
            do
            {
                PrintTurnIndex(turnCounter);
                GameTurn();
                turnCounter += 1;
            } while (!EndGame && turnCounter < Constants.TurnLimit);
            PrintResults();
        }
 
        private void GameTurn()
        {
            for (int i = 0; i < Players.Count && !EndGame; i++)
            {
                TakeTurn(Players[i]);
                EndGame = Players[i].IsBankrupt();
            }
        }

        private void TakeTurn(Player activePlayer)
        {
            int origLoc = activePlayer.Location;
            activePlayer.Move();
            int loc;
            do
            {
                loc = activePlayer.Location;
                Console.WriteLine($"{activePlayer.Name} moves to {Board[loc].Name}");
                Board[activePlayer.Location].Action(activePlayer);
            } while (loc != activePlayer.Location && !activePlayer.IsBankrupt());
            if (loc < origLoc)
            {
                Console.WriteLine($"{activePlayer.Name} passes Go and collects ${Constants.PassGoBonues }");
                activePlayer.AddMoney(Constants.PassGoBonues);
            }
        }

        private void PrintTurnIndex(int TurnIndex)
        {
            Console.WriteLine($"\n========\n Turn: {TurnIndex} \n========\n");
            foreach (Player p in Players)
            {
                Console.WriteLine($"{p.Name} has ${p.Money} and is at square {p.Location} => {Board[p.Location].Name}");
            }
        }

        private void PrintPlayerEndStatus(int winScore, bool findLosers, string message)
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

        private int GetWinnerScore()
        //Returns the maximum score of any players
        {
            int winSum = 0;
            foreach (Player p in Players)
            {
                winSum = Math.Max(winSum, p.Money);
            }
            return winSum;
        }

        private void PrintResults()
        {
            int winScore = GetWinnerScore();

            Console.WriteLine("\n*******\nWinners\n*******\n");
            PrintPlayerEndStatus(winScore, Constants.FindWinner, "wins the game!!!!!");
            Console.WriteLine("*******\nLosers\n*******\n");
            PrintPlayerEndStatus(winScore, Constants.FindLoser, "loses the game :(");
        }
    }
}