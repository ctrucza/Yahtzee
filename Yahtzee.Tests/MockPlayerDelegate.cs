using System;

namespace Yahtzee.Tests
{
    public class MockPlayerDelegate : PlayerDelegate
    {
        public bool HasMoved { get; private set; }

        public void Moved(Player player)
        {
            HasMoved = true;
        }

        public Dice Throw(Player player)
        {
            return new Dice();
        }

        public Selection Select(Player player)
        {
            return new Selection();
        }
    }
}