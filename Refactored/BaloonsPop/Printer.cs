using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    class Printer
    {
        void PrintField(Balloon[,] balloons)
        {
            // gameField.cs => ToString()
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < balloons.GetLength(0); row++)
            {
                Console.Write(row + " | ");

                for (int column = 0; column < balloons.GetLength(1); column++)
                {
                    Console.ForegroundColor = MatchColor(balloons[row, column].Color);
                    Console.Write(balloons[row, column].GetVisualisation() + " ");
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");
        }
    }
}
