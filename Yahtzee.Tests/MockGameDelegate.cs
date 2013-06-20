using System.Collections.Generic;

namespace Yahtzee.Tests
{
    public class MockGameDelegate : GameDelegate
    {
        public int PlayerCount { get { return Players.Count; } }
        public bool GameWasStarted = false;
        public bool GameHasEnded = false;
        public List<Player> Players = new List<Player>();
        private List<Player> playersWhoTookTurns = new List<Player>();

        public void PlayerAdded(Game game, Player player)
        {
            Players.Add(player);
        }

        public void GameStarted(Game game)
        {
            GameWasStarted = true;
        }

        public void CurrentPlayerChanged(Game game, Player player)
        {
            playersWhoTookTurns.Add(player);
        }

        public void GameOver(Game game)
        {
            GameHasEnded = true;
        }

        public bool PlayerHadTurns(Player player)
        {
            return playersWhoTookTurns.Contains(player);
        }
    }
}