using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //does player want to play again?
            char exit = 'y';
            //main loop
            while (exit != 'e')
            //create new game
            {
                Game g = new Game();
                g.NewGame();

                //when game is done, ask for replay
                Console.WriteLine("========================");
                Console.WriteLine("Press any key to play again");
                Console.WriteLine("Press e to exit");
                Console.WriteLine("========================");
                //exit the game from the char variable
                exit = Console.ReadKey().KeyChar;
                //clear console
                Console.Clear();
            }
        }
    }
}
