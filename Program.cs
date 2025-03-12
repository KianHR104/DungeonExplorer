using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        /// <summary>
        /// The main part of the program.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Press any button to start");
            Console.ReadKey();
            Console.Clear();
            Game game = new Game();
            game.Start();
            Console.WriteLine("Waiting for your Implementation");
        }
    }
}
