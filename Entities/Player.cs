namespace XsiOv2.Entities

{
    internal class Player
    {
        private string playerName;
        private string playerSymbol;
        private int playerNumber;

        public Player(string playerName, string playerSymbol, int playerNumber)
        {
            this.playerName = playerName;
            this.playerSymbol = playerSymbol;
            this.playerNumber = playerNumber;   
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public string GetPlayerSymbol()
        {
            return playerSymbol;
        }

        public int GetPlayerNumber()
        {
            return playerNumber;
        }

    }
}
