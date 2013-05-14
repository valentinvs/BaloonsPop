using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    class GameField
    {
        const int GameFieldHeight = 5;
        const int GameFieldWidth = 10;
        public static string[,] gameField = new string[GameFieldHeight, GameFieldWidth];
        private static int ballonsCount = GameFieldHeight * GameFieldWidth;

        public int BallonsCount { get; set; }
        public int ClearedCellsCount { get; set; }

        // TODO: constructor( width, height) - Not needed if the width and height will be left as constants.
        


        /// <summary>
        /// Used to draw the field of the game on the console.
        ///</summary>
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

        /// <summary>
        ///
        ///</summary>
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



        /// <summary>
        /// Used to check if a there is a balloon that should fall 
        /// trought if there is an empty space under it, and update 
        /// its position if needed..
        ///</summary>
        public static void UpdateBalloonsPositions()
        {
            int height = GameFieldHeight - 1;
            int width = GameFieldWidth - 1;

            Queue<string> temp = new Queue<string>();

            for (width; width >= 0; width--)
            {
                for (height; height >= 0; height--)
                {
                    // if balloon is found, push it into the queue
                    if (gameField[height, width] != ".")
                    {
                        // before dot
                        temp.Enqueue(gameField[height, width]);
                        gameField[height, width] = ".";
                    }
                }

                height = GameFieldHeight - 1;

                while (temp.Count > 0)
                {
                    gameField[height, width] = temp.Dequeue();
                    height--;
                }
                temp.Clear();
            }
        }


        /// <summary>
        /// PopsEqualColoredBalloons should check the poped balloon 
        /// neibhours`s colors and pop them if their equal to the 
        /// color of the poped balloon.
        ///</summary>
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
