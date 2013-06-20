using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Yahtzee.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;
        private MockPlayerDelegate playerDelegate;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Joe");
            playerDelegate = new MockPlayerDelegate();
            player.Delegate = playerDelegate;
            
        }
        [Test]
        public void Player_is_done_after_movement()
        {
            Assert.IsFalse(player.IsDone);
            player.Move();
            Assert.IsTrue(player.IsDone);
        }

        [Test]
        public void Player_moves()
        {
            player.Move();
            Assert.IsTrue(playerDelegate.HasMoved);
        }
    }
}
