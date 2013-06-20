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
            Dice dice = Delegate.Throw();
            Delegate.Moved(this);
            IsDone = true;
        }

        public bool IsDone { get; private set; }

        public PlayerDelegate Delegate { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}