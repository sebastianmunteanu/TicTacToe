using System;
using System.Collections.Generic;
using System.Linq;
using XsiOv2.Entities;

namespace XsiOv2
{
    internal class Utils
    {
        public static Camp GetRandomCamp(List<Camp> freeCapms)
        {
            Random rdm = new Random();
            int randomCampIndexNumber = rdm.Next(0, freeCapms.Count);
            return freeCapms.ElementAt(randomCampIndexNumber);
        }

        private static bool EvaluateRows(Board board, ref int whoMove)
        {
            int dim = board.GetBoardDimension();
            int rowElement;
            int matchesContor;
            for (int i = 0; i < dim; i++)
            {
                rowElement = board.camps[i * dim].GetContent();
                matchesContor = 0;
                for (int j = 1; j < dim; j++)
                {
                    if (rowElement == board.camps[(i * dim) + j].GetContent())
                    {
                        matchesContor++;
                    }
                }
                if (matchesContor == dim - 1 && rowElement != 0)
                {
                    whoMove = rowElement;
                    return true;
                } 
            }
            return false;
        }

        private static bool EvaluateColumns(Board board, ref int whoMove)
        {
            int dim = board.GetBoardDimension();
            int columnElement;
            int matchesContor;
            for (int i = 0; i < dim; i++)
            {
                columnElement = board.camps[i].GetContent();
                matchesContor = 0;
                for (int j = 1; j < dim; j++)
                {
                    if (columnElement == board.camps[(dim * j) + i].GetContent())
                    {
                        matchesContor++;
                    }
                }
                if (matchesContor == dim - 1 && columnElement != 0)
                {
                    whoMove = columnElement;
                    return true;
                }
            }
            return false;
        }

        private static bool EvaluateMainDiagonal(Board board, ref int whoMove)
        {
            int dim = board.GetBoardDimension();
            int firstElement = board.camps[0].GetContent();
            int matchesContor = 0;
            for (int i = 1; i < dim; i++)
            {
                if (firstElement == board.camps[(dim * i) +  i].GetContent())
                {
                    matchesContor++;
                }
            }
            whoMove = firstElement;
            return matchesContor == dim - 1 && firstElement != 0;
        }

        private static bool EvaluateSecondDiagonal(Board board, ref int whoMove)
        {
            int dim = board.GetBoardDimension();
            int firstElement = board.camps[dim - 1].GetContent();
            int matchesContor = 0;
            for (int i = 1; i < dim; i++)
            {
                if (firstElement == board.camps[(dim * i) + (dim - i - 1)].GetContent())
                {
                    matchesContor++;
                }
            }
            whoMove = firstElement;
            return matchesContor == dim - 1 && firstElement != 0;
        }

        public static bool EvaluateBoard(Board board, ref int whoMove)
        {
            if (EvaluateRows(board, ref whoMove) || EvaluateColumns(board, ref whoMove) ||
                EvaluateMainDiagonal(board, ref whoMove) || EvaluateSecondDiagonal(board, ref whoMove))
            {
                return true;
            }
            return false;
        }

        public static string whoWin(int x, Player p1, Player p2)
        {
            if (x == p1.GetPlayerNumber())
            {
                return p1.GetPlayerName();
            }

            if  (x == p2.GetPlayerNumber())
            {
                return p2.GetPlayerName();
            }

            return "";
        }
    }
}
