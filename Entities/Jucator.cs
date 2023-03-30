namespace XsiOv2.Entities

{
    internal class Jucator
    {
        private string playerName;
        private string playerSymbol;

        public Jucator(string playerName, string playerSymbol)
        {
            this.playerName = playerName;
            this.playerSymbol = playerSymbol;
        }

        public string GetNumeJucator()
        {
            return playerName;
        }

        public string GetPlayerSymbol()
        {
            return playerSymbol;
        }
    }
}
