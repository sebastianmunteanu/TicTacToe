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
        private string mainPlayerName;
        private string mainPlayerSymbol;
        private string computerSymbol;

        public MainWindow()
        {
            InitializeComponent();
            boardDimmension = 3;
            playerAtributes.Visibility = Visibility.Hidden;

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
                messages = new GameMessages(ref winnerName);
                MessageBox.Show(messages.GetMessage(key));
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

        private void play(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(playerName.Text))
                return;
            else
                mainPlayerName = playerName.Text;

            if (string.IsNullOrEmpty(playerSymbol.Text))
                return;
            else
                mainPlayerSymbol = playerSymbol.Text;

            if (mainPlayerSymbol == "X")
                computerSymbol = "O";
            else
               computerSymbol = "X";

            game = new Game(mainPlayerName, mainPlayerSymbol, computerSymbol);
            playerAtributes.Visibility = Visibility.Hidden;
            game.InitializeGame(boardDimmension);
            board.Visibility = Visibility.Visible;
            CheckIfComputerIsMainPlayer();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {   
            if (!Game.gameBoardInit)
            {
                playerAtributes.Visibility = Visibility.Visible;
            } 
            else
            {
                game.ClearBoardCamps();
                ClearButtonsContent();
                CheckIfComputerIsMainPlayer();
            }
        }

        private void SwitchSymbol(object sender, RoutedEventArgs e)
        {
            if(!Game.gameBoardInit)
            {
                return;
            }
            else
            {
                (mainPlayerSymbol, computerSymbol) = (computerSymbol, mainPlayerSymbol);
                game = new Game(mainPlayerName, mainPlayerSymbol, computerSymbol);
                game.InitializeGame(boardDimmension);
                ClearButtonsContent();
                CheckIfComputerIsMainPlayer();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
