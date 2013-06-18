using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Yahtzee.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;
        private MockGameDelegate gameDelegate;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
            gameDelegate = new MockGameDelegate();
            game.Delegate = gameDelegate;
        }

        [Test]
        public void Test_player_added()
        {
            game.Add(new Player("Joe"));
            Assert.AreEqual(gameDelegate.PlayerCount, 1);
        }

        [Test]
        public void Test_players_are_added()
        {
            Player joe = new Player("Joe");
            Player jane = new Player("Jane");

            game.Add(joe);
            game.Add(jane);

            CollectionAssert.Contains(gameDelegate.Players, joe);
            CollectionAssert.Contains(gameDelegate.Players, jane);
        }

        [Test]
        public void Test_game_starts()
        {
            game.Add(new Player("Joe"));
            game.Start();

            Assert.IsTrue(gameDelegate.GameWasStarted);
        }

        [Test]
        public void Test_game_ends()
        {
            game.Add(new Player("Joe"));
            game.Start();

            Assert.IsTrue(gameDelegate.GameHasEnded);
        }

        [Test]
        public void Test_players_take_turns()
        {
            Player joe = new Player("Joe");
            game.Add(joe);
            game.Start();

            Assert.IsTrue(gameDelegate.PlayerHadTurns(joe));
        }
    }

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
