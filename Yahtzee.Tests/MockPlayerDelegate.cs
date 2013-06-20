using System;

namespace Yahtzee.Tests
{
    public class MockPlayerDelegate : PlayerDelegate
    {
        public void Moved(Player player)
        {
            HasMoved = true;
        }

        public bool HasMoved { get; private set; }
    }
}