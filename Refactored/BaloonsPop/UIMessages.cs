using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    class UIMessages
    {
        // TODO: refactor the messages, they should return string
        // TODO: think about more possible UI messages

        // errorMessage.cs
        private static void PrintInvalidMoveOrCommand()
        {
            Console.WriteLine("Invalid move or command");
            userInput.Clear();
            GameEngine(userInput);
        }

        // errorMessage.cs
        private static void InvalidMove()
        {
            Console.WriteLine("Illegal move: cannot pop missing ballon!");
            userInput.Clear();
            GameEngine(userInput);
        }
    }
}
