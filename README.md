Yahtzee Kata: Delegate approach
===============================

The Yahtzee kata done with an delegate-based approach borrowed from iOS.

Delegates
---------

Delegates appear proeminently in iOS programming: they are used to communicate between the model and UI classes. The delegates resemble the Strategy pattern somehow.

Consider the following class Game:

    class Game
    {
        public void AddPlayer(Player player);
        public void Start();
    }
    
Unit testing the AddPlayer method could look like this:

    public void Test_AddPlayer()
    {
        Game game = new Game();
        game.AddPlayer(new Player());
        
        // How do we test that the player was added?
        // What observable change we expect from the Game class?
    }

One of the approaches is just to expose the Players from the Game:

    public void Test_AddPlayer()
    {
        Game game = new Game();
        Player player = new Player();
        game.AddPlayer(player);
        
        CollectionAssert.Contains(game.Players, player);
        // or similar:
        // Assert.AreEqual(1, game.PlayerCount);
        // Assert.AreEqual(1, game.Players.Count);
        // etc
    }

My pick with this approach is that it exposes some internal details of the Game class.

Another approach is to use delegates:

    class Game
    {
        public GameDelegate Delegate;
        
        public void AddPlayer(Player player)
        {
            // players.Add(player);
            Delegate.PlayerAdded(player);
        }
    }
    class MockGameDelegate: GameDelegate
    {
        public void PlayerAdded(Player player)
        {
            players.Add(player);
        }
    }

... then unit testing is like:

    public void Test_AddPlayer()
    {
        Game game = new Game();
        GameDelegate delegate = new MockGameDelegate();
        game.Delegate = delegate;
        
        Player player = new Player();
        game.AddPlayer(player);
        
        CollectionAssert.Contains(delegate.Players, player);
        
        // or Assert.IsTrue(delegate.PlayerWasAdded(player))
        // or equivalent
    }

By using delegates I can not only tweak my mock delagate implementation to fit my purposes, it also *can* lead (not necessarily *will* lead) to a more decoupled collaboration between the Game class and the UI.

