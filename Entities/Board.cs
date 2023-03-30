﻿using System.Collections.Generic;

namespace XsiOv2.Entities
{
    internal class Board
    {
        public List<Camp> camps;
        public static int numberOfMoves;
        private int boardDimension;

        public Board(int boardDimension)
        {   
            this.boardDimension = boardDimension;
            camps = new List<Camp>();
            numberOfMoves = 0;
        }

        public bool SetCamp(int i, int j, int playerNumber)
        {
            foreach (Camp camp in camps)
            {
                if (camp.GetRow() == i && camp.GetColumn() == j)
                {
                    if (camp.GetContent() == 0)
                    {
                        camp.SetContent(playerNumber);
                    }
                    else
                        return false;
                }
            }
            return true;
        }

        public List<Camp> GetFreeCamps()
        {
            List<Camp> freeCamps = new List<Camp>();
            foreach(Camp c in camps)
            {
                if (c.GetContent() == 0)
                {
                    freeCamps.Add(c);
                }
            }
            return freeCamps;
        }

        public bool BoardIsFull()
        {
            foreach(Camp c in camps)
            {
                if (c.GetContent() == 0)
                    return false;
            }
            return true;
        }

        public int GetBoardDimension()
        {
            return boardDimension;
        }

        public static void IncreaseNumberOfMoves()
        {
            numberOfMoves++;
        }

        public static void ResetNumberOfMoves()
        {
            numberOfMoves = 0;
        }

    }
}
