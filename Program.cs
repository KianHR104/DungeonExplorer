using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Press any button to start");
            Console.ReadKey();
            Console.Clear();
            game.Start();
            Console.WriteLine("Waiting for your Implementation");
        }
    }
}
