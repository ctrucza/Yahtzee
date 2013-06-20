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

            Player joe = new Player("Joe", cliPlayerDelegate);
            game.Add(joe);
            
            Player jane = new Player("Jane", cliPlayerDelegate);
            game.Add(jane);

            game.Start();
        }
    }
}
