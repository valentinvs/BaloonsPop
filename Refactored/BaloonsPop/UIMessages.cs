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
            StringBuilder result = new StringBuilder();

            result.Append("Welcome to “Balloons Pops” game.");
            result.Append("Please try to pop the balloons. ");
            result.Append("Use 'top' to view the top scoreboard, ");
            result.Append("'restart' to start a new game and 'exit' to quit the game.");

            return result.ToString();
        }

        public static string InvalidMove()
        {
            return "Invalid move! The row and col should be in the given range.";
        }

        public static string InvalidCommand()
        {
            return "Invalid command!";
        }

        public static string IllegalMove()
        {
            return "Cannot pop missing ballon!";
        }

        public static string GoodBye()
        {
            return "Good Bye";
        }

        public static string EnterRowCol()
        {
            return "Enter a row and column: ";
        }

        public static string Congratulations()
        {
            return "Congratulations!!! You popped all balloons in ";
        }

        public static string PleaseEnterYourName()
        {
            return "Please enter your name for the top scoreboard: ";
        }

        public static string HighScore()
        {
            return "HighScore: ";
        }
    }
}
