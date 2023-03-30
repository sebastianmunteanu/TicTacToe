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

        private static bool EvaluateRows(Board board)
        {
            int dim = board.GetBoardDimension();
            string rowElement;
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
                if (matchesContor == dim - 1 && !string.IsNullOrEmpty(rowElement))
                {
                    return true;
                } 
            }
            return false;
        }

        private static bool EvaluateColumns(Board board)
        {
            int dim = board.GetBoardDimension();
            string columnElement;
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
                if (matchesContor == dim - 1 && !string.IsNullOrEmpty(columnElement))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool EvaluateMainDiagonal(Board board)
        {
            int dim = board.GetBoardDimension();
            string firstElement = board.camps[0].GetContent();
            int matchesContor = 0;
            for (int i = 1; i < dim; i++)
            {
                if (firstElement == board.camps[(dim * i) +  i].GetContent())
                {
                    matchesContor++;
                }
            }
            return matchesContor == dim - 1 && !string.IsNullOrEmpty(firstElement);
        }

        private static bool EvaluateSecondDiagonal(Board board)
        {
            int dim = board.GetBoardDimension();
            string firstElement = board.camps[dim - 1].GetContent();
            int matchesContor = 0;
            for (int i = 1; i < dim; i++)
            {
                if (firstElement == board.camps[(dim * i) + (dim - i - 1)].GetContent())
                {
                    matchesContor++;
                }
            }
            return matchesContor == dim - 1 && !string.IsNullOrEmpty(firstElement);
        }

        public static bool EvaluateBoard(Board board)
        {
            if (EvaluateRows(board) || EvaluateColumns(board) ||
                EvaluateMainDiagonal(board) || EvaluateSecondDiagonal(board))
            {
                return true;
            }
            return false;
        }
    }
}
