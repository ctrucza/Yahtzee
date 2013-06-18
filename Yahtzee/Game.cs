using System;

namespace Yahtzee
{
    public class Game
    {
        public GameDelegate Delegate;

        public void Add(Player player)
        {
            Delegate.PlayerAdded(this, player);
        }

        public void Start()
        {
            Delegate.GameStarted(this);
        }

        public bool IsOver()
        {
            return false;
        }

        public void Turn()
        {
            Delegate.CurrentPlayerChanged(this, null);
        }

        public void ShowResults()
        {
            Console.WriteLine("Results");
        }
    }

    public interface GameDelegate
    {
        void PlayerAdded(Game game, Player player);
        void GameStarted(Game game);
        void CurrentPlayerChanged(Game game, Player player);
        void GameOver(Game game);
    }
}