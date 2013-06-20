using System.Collections.Generic;

namespace Yahtzee
{
    public interface PlayerDelegate
    {
        void Moved(Player player);
        Dice Throw(Player player);
        Line SelectLine(Player player, IEnumerable<Line> unknown);
        List<Line> GetLines();
    }
}