using System.Collections.Generic;

namespace Yahtzee
{
    public interface PlayerDelegate
    {
        List<Line> GetLines();

        // operations
        Dice Throw(Player player);
        Line SelectLine(Player player, IEnumerable<Line> unknown);

        // event callbacks
        void Moved(Player player);
    }
}