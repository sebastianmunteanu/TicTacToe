using System;
using System.Collections.Generic;
using XsiOv2.Entities;

namespace XsiOv2
{
    internal class Game
    {
        Board board;
        List<Camp> freeCapms;
        private bool gameOver;
        public static bool gameBoardInit;
        private Player mainPlayer;
        private Player computer;
        private const int mainPlayerNumber = 1;
        private const int computerNumber = 2;

        public Game(string playerName, string playerSymbol, string computerSymbol)
        {
            string computerName = "Computerul";
            gameOver = false;
            mainPlayer = new Player(playerName, playerSymbol, mainPlayerNumber);
            computer = new Player(computerName, computerSymbol, computerNumber);
        }

        public string mainPlayerSymbol()
        {
            return mainPlayer.GetPlayerSymbol();
        }

        public void InitializeGame(int dim)
        {
            board = new Board(dim);
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    Camp c = new Camp(i, j, 0);
                    board.camps.Add(c);
                }
            }
            gameBoardInit = true;
        }

        public bool PlayerMove(int i, int j, ref string symbol)
        {
            if(gameOver)
            {
                return false;
            }
            if (board.SetCamp(i, j, mainPlayer.GetPlayerNumber()))
            {
                symbol = mainPlayer.GetPlayerSymbol();
                Board.IncreaseNumberOfMoves();
                return true;
            }
            return false;
        }

        public bool AutomatMove(ref Tuple<int, int, string> automatMoveDetails)
        {
            if (gameOver || board.BoardIsFull())
            {
                return false;
            }

            Camp choseCamp;
            freeCapms = board.GetFreeCamps();

            if (freeCapms.Count > 0)
            {
                choseCamp = Utils.GetRandomCamp(freeCapms);
                board.SetCamp(choseCamp.GetRow(),
                              choseCamp.GetColumn(),
                              computer.GetPlayerNumber());
                automatMoveDetails = Tuple.Create(choseCamp.GetRow(), choseCamp.GetColumn(), computer.GetPlayerSymbol());
                return true;
            }
            return true;
        }

        public int EvaluateGame(ref string winnerName)
        {
            int whoMove = 0;
            if (Board.numberOfMoves >= 2)
            {
                if (Utils.EvaluateBoard(board, ref whoMove))
                {
                    gameOver = true;
                    winnerName = Utils.whoWin(whoMove, mainPlayer, computer);
                    return 13 - whoMove;
                }
                
                if (board.BoardIsFull())
                {
                    winnerName = "";
                    return 10;
                }
            }
            return 0;
        }

        public void ClearBoardCamps()
        {
            Board.ResetNumberOfMoves();
            Board.numberOfCoveredCamps = 0;
            gameOver = false;
            foreach (Camp camp in board.camps)
            {
                camp.SetContent(0);
            }
        }
    }
}

