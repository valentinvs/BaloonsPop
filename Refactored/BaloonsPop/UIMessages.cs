using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public static class UIMessages
    {
        public static string Greetings()
        {
            string message = "Welcome to “Balloons Pops” game. ";
            message += "Please try to pop the balloons. ";
            message += "Use 'top' to view the top scoreboard, ";
            message += "'restart' to start a new game and 'exit' to quit the game.";

            return message;
        }

        // errorMessage.cs
        private static void PrintInvalidMoveOrCommand()
        {
            Console.WriteLine("Invalid move or command");
            //userInput.Clear();
            //GameEngine(userInput);
        }

        // errorMessage.cs
        private static void InvalidMove()
        {
            Console.WriteLine("Illegal move: cannot pop missing ballon!");
            //userInput.Clear();
            //GameEngine(userInput);
        }
    }
}
