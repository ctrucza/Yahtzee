using NUnit.Framework;

namespace Yahtzee.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;
        private MockGameDelegate gameDelegate;
        private Player joe;

        [SetUp]
        public void SetUp()
        {
            gameDelegate = new MockGameDelegate();
            game = new Game(gameDelegate);

            joe = new Player("Joe", gameDelegate.GetPlayerDelegate());
        }

        [Test]
        public void Test_player_added()
        {
            game.Add(joe);
            Assert.AreEqual(gameDelegate.PlayerCount, 1);
        }

        [Test]
        public void Test_players_are_added()
        {
            Player joe = this.joe;
            Player jane = new Player("Jane", gameDelegate.GetPlayerDelegate());

            game.Add(joe);
            game.Add(jane);

            CollectionAssert.Contains(gameDelegate.Players, joe);
            CollectionAssert.Contains(gameDelegate.Players, jane);
        }

        [Test]
        public void Test_game_starts()
        {
            game.Add(joe);
            game.Run();

            Assert.IsTrue(gameDelegate.GameWasStarted);
        }

        [Test]
        public void Test_game_ends()
        {
            game.Add(joe);
            game.Run();

            Assert.IsTrue(gameDelegate.GameHasEnded);
        }

        [Test]
        public void Test_players_take_turns()
        {
            Player joe = this.joe;
            game.Add(joe);
            game.Run();

            Assert.IsTrue(gameDelegate.PlayerHadTurns(joe));
        }
    }
}
