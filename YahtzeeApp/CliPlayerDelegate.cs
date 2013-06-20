using System;
using System.Collections.Generic;
using System.Linq;
using Yahtzee;

namespace YahtzeeApp
{
    internal class CliPlayerDelegate : PlayerDelegate
    {
        public void Moved(Player player)
        {
            Console.WriteLine("{0} moved", player);
        }

        public Dice Throw(Player player)
        {
            Console.WriteLine("{0} threw dice", player);
            return new Dice();
        }

        public Line SelectLine(Player player, IEnumerable<Line> availableSelections)
        {
            Console.WriteLine("{0} selected a line to put his dice on", player);
            return availableSelections.First();
        }

        public List<Line> GetLines()
        {
            return new List<Line>
                {
                    new Line(),
                    new Line()
                };
        }
    }
}