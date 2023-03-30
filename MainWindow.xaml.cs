using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace XsiOv2
{
    public partial class MainWindow : Window
    {   
        private Game game;
        private GameMessages messages;
        private bool gameStart = false;
        private int boardDimmension;
        private const string mainSimbol = "X";
        private string winnerName;

        public MainWindow()
        {
            InitializeComponent();
            messages = new GameMessages();
            boardDimmension = 3;
           
            if (!gameStart)
            {
                board.Visibility = Visibility.Hidden;
            }
        }

        private void ClearButtonsContent()
        {
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < boardDimmension; i++)
            {   
                for (int j = 0; j < boardDimmension; j++)
                {
                    buttons.Add((Button)this.FindName("b" + i.ToString() + j.ToString()));
                }
            }

            foreach(Button btn in buttons)
            {
                btn.Content = "";
            }
        }

        private void CheckIfComputerIsMainPlayer()
        {
            if (game.mainPlayerSymbol() != mainSimbol)
            {
                ComputerMove();
            }
        }

        private void PrintMessage(int key)
        {
            if (key != 0)
            {
                MessageBox.Show(messages.GetMessage(key), winnerName);
            }
        }

        private void ComputerMove()
        {
            Tuple<int, int, string> automatMoveDetails = new Tuple<int, int, string>(-1, -1, "");

            if (game.AutomatMove(ref automatMoveDetails))
            {
                Button computerBtn = (Button)this.FindName("b" + automatMoveDetails.Item1.ToString() +
                                                                 automatMoveDetails.Item2.ToString());
                computerBtn.Content = automatMoveDetails.Item3;
                PrintMessage(game.EvaluateGame(ref winnerName));
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int i, j;
            string symbol = "";

            if (!int.TryParse(button.Name.Substring(1,1), out i))
            {
                return;
            }

            if (!int.TryParse(button.Name.Substring(2,1), out j))
            {
                return;
            }

            if (game.PlayerMove(i, j, ref symbol))
            {
                button.Content = symbol;
                PrintMessage(game.EvaluateGame(ref winnerName));
                ComputerMove();
            }
            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {   
            if (!Game.gameBoardInit)
            {
                game = new Game("alex", "O", "X");
                game.InitializeGame(boardDimmension);
                board.Visibility = Visibility.Visible;
                CheckIfComputerIsMainPlayer();
            } 
            else
            {
                game.ClearBoardCamps();
                ClearButtonsContent();
                CheckIfComputerIsMainPlayer();
            }
        }
    }
}
