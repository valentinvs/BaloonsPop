using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    class GameField
    {
        // this goes to gameField.cs
        const int GameFieldHeight = 5;
        const int GameFieldWidth = 10;
        public static string[,] gameField = new string[GameFieldHeight, GameFieldWidth];
        private static int ballonsCount = GameFieldHeight * GameFieldWidth;

        public int BallonsCount { get; set; }
        public int ClearedCellsCount { get; set; }

        // TODO: fields/properties for ballonsCount, clearedCellsCount
        // TODO: constructor( width, height)
      
        
        // TODO: Refactor ToString()
        public override string ToString()
        {
            // gameField.cs => ToString()
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < GameFieldHeight; row++)
            {
                Console.Write(row + " | ");

                for (int col = 0; col < GameFieldWidth; col++)
                {
                    Console.Write(gameField[row, col] + " ");
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");

            return "";
        }

        // TODO: Refactor initialize the field (some random numbers from RandomClass, which returns random number)
        public static void InitiliazeGameField()
        {
            //ballonsCount = GameFieldHeight * GameFieldWidth;
            //playerMoveCount = 0;
            //clearedCellsCount = 0;
            // gameField set method
            for (int row = 0; row < GameFieldHeight; row++)
            {
                for (int col = 0; col < GameFieldWidth; col++)
                {
                    gameField[row, col] = RandomNumberGenerator.GetRandomInt();
                }
            }
        }

        // TODO: refactor method for gravity effect
        public static void UpdateBalloonsPositions()
        {
            int i;
            int j;

            Queue<string> temp = new Queue<string>();

            for (j = GameFieldWidth - 1; j >= 0; j--)
            {
                for (i = GameFieldHeight - 1; i >= 0; i--)
                {
                    // if balloon is found, push it into the queue
                    if (gameField[i, j] != ".")
                    {
                        // before dot
                        temp.Enqueue(gameField[i, j]);
                        gameField[i, j] = ".";
                    }
                }

                i = GameFieldHeight - 1;

                while (temp.Count > 0)
                {
                    gameField[i, j] = temp.Dequeue();
                    i--;
                }
                temp.Clear();
            }
        }

        // TODO: refactor method
        public static void PopsEqualColoredBalloons(int i, int j, string selectedBalloon)
        {
            if ((i >= 0) && (i <= GameFieldHeight - 1) && (j <= GameFieldWidth - 1) && (j >= 0) && (gameField[i, j] == selectedBalloon))
            {
                gameField[i, j] = ".";
                clearedCellsCount++;
                //Up
                PopsEqualColoredBalloons(i - 1, j, selectedBalloon);
                //Down
                PopsEqualColoredBalloons(i + 1, j, selectedBalloon);
                //Left
                PopsEqualColoredBalloons(i, j + 1, selectedBalloon);
                //Right
                PopsEqualColoredBalloons(i, j - 1, selectedBalloon);
            }
            else
            {
                ballonsCount -= clearedCellsCount;
                clearedCellsCount = 0;
                return;
            }
        }

        
    }
}
