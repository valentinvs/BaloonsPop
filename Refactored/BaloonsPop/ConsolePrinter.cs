using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public static class ConsolePrinter
    {
        public static void Message(string message)
        {
            Console.Write(message);
        }
        /// <summary>
        /// Print the Gamefield on the console
        /// </summary>
        /// <param name="balloons"></param>
        public static void PrintGameField(Balloon[,] balloons)
        {
            ResetConsoleColor();

            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < balloons.GetLength(0); row++)
            {
                Console.Write(row + " | ");

                for (int column = 0; column < balloons.GetLength(1) ; column++)
                {
                    Console.ForegroundColor = Utilities.MatchColor(balloons[row, column].Color);
                    Console.Write(balloons[row, column].GetVisualisation() + " ");
                }

                ResetConsoleColor();

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");
        }

        private static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
