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
            Game game = new Game();
            game.Delegate = new CliDelegate();
            game.Add(new Player("Joe"));
            game.Add(new Player("Jane"));

            game.Start();
        }
    }
}
