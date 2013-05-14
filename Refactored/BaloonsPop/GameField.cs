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
        public static int clearedCellsCount = 0;

        private static Balloon[,] balloons = new Balloon[GameFieldHeight, GameFieldWidth]();

        //public static string[,] gameField = new string[GameFieldHeight, GameFieldWidth];
        //Color[,] color;

        //public Color Color { get; protected set; }

        public int BallonsCount { get; set; }//extract to bBalloons+
        //public int ClearedCellsCount { get; set; }
        private static int ballonsCount = GameFieldHeight * GameFieldWidth;

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

                for (int column = 0; column < GameFieldWidth; column++)
                {
                    Console.ForegroundColor = this.MatchColor(balloons[row, column].Color);
                    Console.Write(balloons[row, column].GetVisualisation() + " ");
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");

            return "";
        }

        private ConsoleColor MatchColor(Color color)
        {
            ConsoleColor matchColor;

            switch (color)
            {
                case Color.Blue:
                    matchColor = ConsoleColor.Blue;
                    break;
                case Color.Green:
                    matchColor = ConsoleColor.Green;
                    break;
                case Color.Red:
                    matchColor = ConsoleColor.Red;
                    break;
                case Color.Yellow:
                    matchColor = ConsoleColor.Yellow;
                    break;
                default:
                    matchColor = ConsoleColor.White;
                    break;
            }

            return matchColor;
        }

        /// <summary>
        /// Fill the game field with "balloons" by getting random 
        /// numbers from the RandomNumberGenerator class.
        ///</summary>
        public static void InitiliazeGameField()
        {
            //playerMoveCount = 0;
            //clearedCellsCount = 0;
            // gameField set method

            //helps to generate random color
            Array colors = Enum.GetValues(typeof(Color));
            Color balloonColor;

            for (int row = 0; row < GameFieldHeight; row++)
            {
                for (int col = 0; col < GameFieldWidth; col++)
                {
                    balloonColor= (Color)colors.GetValue(RandomNumberGenerator.Instance.Next(0, colors.Length - 1));
                    balloons[row, col] = new Balloon(balloonColor);
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
        public static void PopsEqualColoredBalloons(int i, int j, Balloon selectedBalloon)
        {
            if ((i >= 0) && (i <= GameFieldHeight - 1) && (j <= GameFieldWidth - 1) && (j >= 0) && (balloons[i, j].Color == selectedBalloon.Color))
            {
                if (!balloons[i, j].IsPop)
                {
                    balloons[i, j].Pop();

                    clearedCellsCount++;

                    //Check Up balloon.
                    PopsEqualColoredBalloons(i - 1, j, selectedBalloon);
                    //Check Down balloon.
                    PopsEqualColoredBalloons(i + 1, j, selectedBalloon);
                    //Check Left balloon.
                    PopsEqualColoredBalloons(i, j + 1, selectedBalloon);
                    //Check Right balloon.
                    PopsEqualColoredBalloons(i, j - 1, selectedBalloon);
                }

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
