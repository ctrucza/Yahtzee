namespace Yahtzee
{
    public interface PlayerDelegate
    {
        void Moved(Player player);
        Dice Throw(Player player);
        Selection Select(Player player);
    }
}