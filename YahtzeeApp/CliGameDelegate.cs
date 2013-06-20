using System;
using Yahtzee;

namespace YahtzeeApp
{
    internal class CliGameDelegate : GameDelegate
    {
        public void PlayerAdded(Game game, Player player)
        {
            Console.WriteLine("Player added {0}", player);
        }

        public void GameStarted(Game game)
        {
            Console.WriteLine("Game started");
        }

        public void CurrentPlayerChanged(Game game, Player player)
        {
            Console.WriteLine("Current player is {0}", player);
        }

        public void GameOver(Game game)
        {
            Console.WriteLine("Game ended");
        }

        public PlayerDelegate GetPlayerDelegate()
        {
            return new CliPlayerDelegate();
        }
    }
}