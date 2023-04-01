using System.Collections.Generic;

namespace XsiOv2
{
    internal class GameMessages
    {
        private Dictionary<int, string> gameMessages = new Dictionary<int, string>();
        public GameMessages(ref string winnerName)
        {
            gameMessages.Add(10, "Remiza");
            gameMessages.Add(11, $"Game over! {winnerName} a castigat :( incercati din nou!");
            gameMessages.Add(12, $"Felicitari {winnerName} ai castigat!");
        }

        public string GetMessage(int key)
        {
            return gameMessages[key];
        }
    }
}
