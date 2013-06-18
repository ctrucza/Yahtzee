using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class Game
    {
        public GameDelegate Delegate;
        private Player currentPlayer;
        private List<Player> players = new List<Player>();

        public void Add(Player player)
        {
            players.Add(player);
            Delegate.PlayerAdded(this, player);
        }

        public void Start()
        {
            Delegate.GameStarted(this);

            while (!IsOver())
            {
                Turn();
            }

            Delegate.GameOver(this);
        }

        private bool IsOver()
        {
            return players.All(player => player.IsDone);
        }

        public void Turn()
        {
            MoveToNextPlayer();
            currentPlayer.Move();
        }

        private void MoveToNextPlayer()
        {
            Player player = GetNextPlayer();
            SetCurrentPlayer(player);
        }

        private void SetCurrentPlayer(Player player)
        {
            currentPlayer = player;
            Delegate.CurrentPlayerChanged(this, currentPlayer);
        }

        private Player GetNextPlayer()
        {
            int index = players.IndexOf(currentPlayer);
            if (index == players.Count)
                index = 0;
            else
                index++;
            return players[index];
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