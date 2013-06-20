namespace Yahtzee
{
    public class Player
    {
        private readonly string name;
        private PlayerDelegate playerDelegate;

        public Player(string name)
        {
            this.name = name;
        }

        public void Move()
        {
            Delegate.Moved(this);
            IsDone = true;
        }

        public bool IsDone { get; private set; }

        public PlayerDelegate Delegate
        {
            get
            {
                if (playerDelegate == null)
                    playerDelegate = new DefaultPlayerDelegate();
                return playerDelegate;
            }
            set { playerDelegate = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}