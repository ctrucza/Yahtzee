using System;
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
        [Test]
        public void Test_usage()
        {
            Game game = new Game();
            // WHat do we test here?
            // What is the observable behaviour?

            game.Add(new Player("Joe"));
            // what would we test here?

            game.Start();

            while (!game.IsOver())
            {
                game.Turn();
            }

            game.ShowResults();
        }
    }
}
