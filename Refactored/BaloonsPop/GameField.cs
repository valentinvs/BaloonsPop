using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public class GameField
    {
        public const int FieldHeight = 5;
        public const int FieldWidth = 10;

        public const string LeftWall = " | ";
        public const string RightWall = "| ";
        public const string TopWall = "-";
        public const string BottomWall = "-";


        private readonly int gameFieldWidth;
        private readonly int gameFieldHeight;

        private Balloon[,] balloons;
        private int ballonsCount;
        private int clearedCellsCount;

        public GameField()
        {
            this.gameFieldWidth = FieldWidth;
            this.gameFieldHeight = FieldHeight;
            this.balloons = new Balloon[FieldHeight, FieldWidth];
            this.ballonsCount = FieldHeight * FieldWidth;
            this.clearedCellsCount = 0;

            this.InitiliazeGameField();
        }



        public int ClearedCellsCount
        {
            get
            {
                return this.clearedCellsCount;
            }
            private set
            {
                this.clearedCellsCount = value;
            }
        }

        public int GameFieldWidth
        {
            get
            {
                return this.gameFieldWidth;
            }
        }

        public int GameFieldHeight
        {
            get
            {
                return this.gameFieldHeight;
            }
        }

        public int BallonsCount
        {
            get
            {
                return ballonsCount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value is negative");
                }

                this.ballonsCount = value;
            }
        }

        public Balloon[,] BalloonsMatrix
        {
            get
            {
                return this.balloons;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The given argument is null.");
                }

                this.balloons = value;
            }

        }

        /// <summary>
        /// Used to draw the field of the game on the console.
        ///</summary>
        // TODO: Refactor ToString()
        public override string ToString()
        {
            // gameField.cs => ToString()
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < FieldHeight; row++)
            {
                Console.Write(row + " | ");

                for (int column = 0; column < FieldWidth; column++)
                {
                    Console.ForegroundColor = Utilities.MatchColor(balloons[row, column].Color);
                    Console.Write(balloons[row, column].GetVisualisation() + " ");
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");

            return "";
        }

       

        /// <summary>
        /// Fill the game field with "balloons" by getting random 
        /// numbers from the RandomNumberGenerator class.
        ///</summary>
        private void InitiliazeGameField()
        {
            //playerMoveCount = 0;
            //clearedCellsCount = 0;
            // gameField set method

            //helps to generate random color
            Array colors = Enum.GetValues(typeof(Color));
            Color balloonColor;

            for (int row = 0; row < FieldHeight; row++)
            {
                for (int col = 0; col < FieldWidth; col++)
                {
                    balloonColor = (Color)colors.GetValue(RandomNumberGenerator.Instance.Next(0, colors.Length - 1));
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
            //int height = FieldHeight - 1;
            //int width = FieldWidth - 1;

            //Queue<string> temp = new Queue<string>();

            //for (width; width >= 0; width--)
            //{
            //    for (height; height >= 0; height--)
            //    {
            //        // if balloon is found, push it into the queue
            //        if (gameField[height, width] != ".")
            //        {
            //            // before dot
            //            temp.Enqueue(gameField[height, width]);
            //            gameField[height, width] = ".";
            //        }
            //    }

            //    height = FieldHeight - 1;

            //    while (temp.Count > 0)
            //    {
            //        gameField[height, width] = temp.Dequeue();
            //        height--;
            //    }
            //    temp.Clear();
            //}
        }

        /// <summary>
        /// PopsEqualColoredBalloons should check the poped balloon 
        /// neibhours`s colors and pop them if their equal to the 
        /// color of the poped balloon.
        ///</summary>
        //public static void PopsEqualColoredBalloons(int i, int j, Balloon selectedBalloon)
        //{
        //    if ((i >= 0) && (i <= FieldHeight - 1) && (j <= FieldWidth - 1) && (j >= 0) && (balloons[i, j].Color == selectedBalloon.Color))
        //    {
        //        if (!balloons[i, j].IsPop)
        //        {
        //            balloons[i, j].Pop();

        //            clearedCellsCount++;

        //            //Check Up balloon.
        //            PopsEqualColoredBalloons(i - 1, j, selectedBalloon);
        //            //Check Down balloon.
        //            PopsEqualColoredBalloons(i + 1, j, selectedBalloon);
        //            //Check Left balloon.
        //            PopsEqualColoredBalloons(i, j + 1, selectedBalloon);
        //            //Check Right balloon.
        //            PopsEqualColoredBalloons(i, j - 1, selectedBalloon);
        //        }

        //    }
        //    else
        //    {
        //        ballonsCount -= clearedCellsCount;
        //        clearedCellsCount = 0;

        //        return;
        //    }
        //}
    }
}
