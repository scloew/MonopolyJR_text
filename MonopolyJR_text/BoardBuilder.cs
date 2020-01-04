using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyJR_text
{
    static class BoardBuilder
    {


        private static void buildProperties(MonopolySquare[] board)
        {
            //Tuple<board index, rent price, name>
            Tuple<int, int, string>[] properties = { Tuple.Create(2, 1, "Magenta"),  Tuple.Create(6, 2, "Azure"), Tuple.Create(11, 2, "Purple"),
                                            Tuple.Create(14, 3, "Oragne"), Tuple.Create(18, 3, "Red"), Tuple.Create(22, 4, "Yellow"),
                                            Tuple.Create(27, 4, "Green"), Tuple.Create(30, 5, "Blue")};

            foreach (Tuple<int, int, string> prop in properties)
            //loop to initialize all board properties
            {
                MonopolyProperty mp1 = new MonopolyProperty(prop.Item3 + " 1", prop.Item2);
                MonopolyProperty mp2 = new MonopolyProperty(prop.Item3 + " 2", prop.Item2 + 1);

                mp1.setNeighbor(mp2);
                mp2.setNeighbor(mp1);

                board[prop.Item1] = mp1;
                board[prop.Item1 + 1] = mp2;
            }
        }

        private static void buildRailroads(MonopolySquare[] board)
        {
            //Tuple<board index, name>
            Tuple<int, string>[] railRoads = {Tuple.Create(5, "yellow railroad"),  Tuple.Create(13, "green railroad"),
                                                Tuple.Create(21, "blue railroad"), Tuple.Create(29, "red railroad")};

            foreach (Tuple<int, string> r in railRoads)
            {
                board[r.Item1] = new RailRoad(r.Item2);

            }
        }

        private static void buildTax(MonopolySquare[] board, LooseChange lc)
        {
            board[8] = new TaxSquare("fire works", 2, lc);
            board[24] = new TaxSquare("water works", 2, lc);
        }

        private static void buildSingletons(MonopolySquare[] board, LooseChange lc)
        //Build Squares for which there is only one instance
        {
            board[0] = new GoSquare("Go");
            board[10] = new Bathroom("bathroom");
            board[26] = new GoToBathroom("Go to bathroom", 3, lc);
            board[1] = board[4] = board[9] = board[17] =
                 board[20] = board[25] = new ChanceSquare("Chance");
        }

        public static void buildBoard(MonopolySquare[] board)
        {
            if (board.Length != 32)
            {
                throw new System.ArgumentException("Invalid board Length");
            }

            LooseChange lc = new LooseChange("loose change");
            board[16] = lc;
            buildProperties(board);
            buildRailroads(board);
            buildTax(board, lc);
            buildSingletons(board, lc);
        }
    }
}
