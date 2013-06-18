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
            IsDone = true;
        }

        public bool IsDone { get; private set; }

        public override string ToString()
        {
            return name;
        }
    }
}