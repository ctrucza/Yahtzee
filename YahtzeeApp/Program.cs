using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee;

namespace YahtzeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new CliGameDelegate());
            CliPlayerDelegate cliPlayerDelegate = new CliPlayerDelegate();

            Player joe = new Player("Joe");
            joe.Delegate = cliPlayerDelegate;
            game.Add(joe);
            
            Player jane = new Player("Jane");
            jane.Delegate = cliPlayerDelegate;
            game.Add(jane);

            game.Start();
        }
    }

    internal class CliPlayerDelegate : PlayerDelegate
    {
        public void Moved(Player player)
        {
            Console.WriteLine("{0} moved", player);
        }

        public Dice Throw(Player player)
        {
            Console.WriteLine("{0} threw dice", player);
            return new Dice();
            throw new NotImplementedException();
        }
    }
}
