﻿using NUnit.Framework;

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
            gameDelegate = new MockGameDelegate();
            game = new Game(gameDelegate);
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
}
