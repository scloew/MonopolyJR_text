﻿using System;
using System.Collections.Generic;

namespace MonopolyJR_text
{
    static class BoardBuilder
    {
        public static List<MonopolySquare> BuildBoard()
        {
            List<MonopolySquare> board = new List<MonopolySquare>(new MonopolySquare[32]);
            LooseChangeSquare lc = new LooseChangeSquare("loose change");
            board[16] = lc;
            BuildProperties(board);
            BuildRailroads(board);
            BuildTax(board, lc);
            BuildSingletons(board, lc);
            return board;
        }

        private static void BuildProperties(List<MonopolySquare> board)
        {
            //Tuple<board index, rent price, name>
            Tuple<int, int, string>[] properties = { Tuple.Create(2,  1, "Magenta"),  Tuple.Create(6, 2, "Azure"),
                                                     Tuple.Create(11, 2, "Purple"), Tuple.Create(14, 3, "Orange"),
                                                     Tuple.Create(18, 3, "Red"), Tuple.Create(22, 4, "Yellow"),
                                                     Tuple.Create(27, 4, "Green"), Tuple.Create(30, 5, "Blue")};

            foreach (Tuple<int, int, string> prop in properties)
            //loop to initialize all board properties
            {
                PropertySquare mp1 = new PropertySquare($"{prop.Item3} 1", prop.Item2);
                PropertySquare mp2 = new PropertySquare($"{prop.Item3} 2", prop.Item2);

                PropertyPair monopoly = new PropertyPair(mp1, mp2);
                mp1.SetCheckMonopoly(monopoly);
                mp2.SetCheckMonopoly(monopoly);
                board[prop.Item1] = mp1;
                board[prop.Item1 + 1] = mp2;
            }
        }

        private static void BuildRailroads(List<MonopolySquare> board)
        {
            //Tuple<board index, name>
            Tuple<int, string>[] railRoads = {Tuple.Create(5, "yellow railroad"),  Tuple.Create(13, "green railroad"),
                                                Tuple.Create(21, "blue railroad"), Tuple.Create(29, "red railroad")};

            foreach (Tuple<int, string> r in railRoads)
            {
                board[r.Item1] = new RailRoadSquare(r.Item2);

            }
        }

        private static void BuildTax(List<MonopolySquare> board, LooseChangeSquare lc)
        {
            board[8] = new TaxSquare("fire works", Constants.Tax, lc);
            board[24] = new TaxSquare("water works", Constants.Tax, lc);
        }

        private static void BuildSingletons(List<MonopolySquare> board, LooseChangeSquare lc)
        //Build Squares for which there is only one instance
        {
            board[0] = new GoSquare("Go");
            board[10] = new BathroomSquare("bathroom");
            board[26] = new GoToBathroom("Go to bathroom", Constants.BathroomTax, lc, 10);
            board[1] = board[4] = board[9] = board[17] =
                 board[20] = board[25] = new ChanceSquare("Chance");
        }
    }
}
