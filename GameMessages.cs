using System.Collections.Generic;

namespace XsiOv2
{
    internal class GameMessages
    {
        private Dictionary<int, string> gameMessages = new Dictionary<int, string>();
        public GameMessages()
        {
            gameMessages.Add(10, "Remiza");
            gameMessages.Add(11, "Game over! Calculatorul a castigat incerca din nou");
            gameMessages.Add(12, "Felicitari alex ai castigat");
        }

        public string GetMessage(int key)
        {
            return gameMessages[key];
        }
    }
}
