namespace Yahtzee
{
    public class Player
    {
        private readonly string name;

        public Player(string name)
        {
            this.name = name;
        }

        public void Move()
        {
            Dice dice = Delegate.Throw(this);
            Selection selection = Delegate.Select(this);

            Score(dice, selection);

            Delegate.Moved(this);
            IsDone = true;
        }

        private void Score(Dice dice, Selection selection)
        {
        }

        public bool IsDone { get; private set; }

        public PlayerDelegate Delegate { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class Selection 
    {
    }
}