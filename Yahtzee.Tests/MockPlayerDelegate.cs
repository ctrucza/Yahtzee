﻿using System.Collections.Generic;
using System.Linq;

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

        public Line SelectLine(Player player, IEnumerable<Line> availableSelections)
        {
            return availableSelections.First();
        }

        public List<Line> GetLines()
        {
            return new List<Line>
                {
                    new Line()
                };
        }
    }
}