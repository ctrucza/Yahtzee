using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class Player
    {
        private readonly string name;
        private readonly PlayerDelegate playerDelegate;
        private readonly List<Line> lines;

        public Player(string name, PlayerDelegate playerDelegate)
        {
            this.name = name;
            this.playerDelegate = playerDelegate;
            lines = this.playerDelegate.GetLines();
        }

        public void Move()
        {
            Dice dice = playerDelegate.Throw(this);
            Line line = playerDelegate.SelectLine(this, lines.Where(s=>!s.Scored));
            line.Score(dice);

            playerDelegate.Moved(this);

        }

        public bool IsDone()
        {
            return lines.All(s => s.Scored);
        }

        public override string ToString()
        {
            return name;
        }
    }
}