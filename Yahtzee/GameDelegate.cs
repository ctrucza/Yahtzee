namespace Yahtzee
{
    public interface GameDelegate
    {
        // event callbacks
        void PlayerAdded(Game game, Player player);
        void GameStarted(Game game);
        void CurrentPlayerChanged(Game game, Player player);
        void GameOver(Game game);

        PlayerDelegate GetPlayerDelegate();
    }
}