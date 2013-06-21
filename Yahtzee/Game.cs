using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class Game
    {
        private readonly GameDelegate gameDelegate;
        private Player currentPlayer;
        private readonly List<Player> players = new List<Player>();

        public Game(GameDelegate gameDelegate)
        {
            this.gameDelegate = gameDelegate;
        }

        public void Add(Player player)
        {
            players.Add(player);
            gameDelegate.PlayerAdded(this, player);
        }

        public void Start()
        {
            gameDelegate.GameStarted(this);

            while (!IsOver())
            {
                Turn();
            }

            gameDelegate.GameOver(this);
        }

        private bool IsOver()
        {
            return players.All(player => player.IsDone());
        }

        private void Turn()
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
            gameDelegate.CurrentPlayerChanged(this, currentPlayer);
        }

        private Player GetNextPlayer()
        {
            int index = players.IndexOf(currentPlayer);
            if (index == players.Count-1)
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
}