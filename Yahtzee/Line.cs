namespace Yahtzee
{
    public class Line 
    {
        public void Score(Dice dice)
        {
            Scored = true;
        }

        public bool Scored { get; private set; }
    }
}