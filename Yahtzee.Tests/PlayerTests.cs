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
        [Test]
        public void Player_is_done_after_movement()
        {
            Player player = new Player("Joe");
            Assert.IsFalse(player.IsDone);
            player.Move();
            Assert.IsTrue(player.IsDone);
        }

        [Test]
        public void Player_moves()
        {
            Player player = new Player("joe");
            player.Move();
            MockPlayerDelegate playerDelegate = new MockPlayerDelegate();
            player.Delegate = playerDelegate;
            player.Move();
            Assert.IsTrue(playerDelegate.HasMoved);
        }
    }
}
