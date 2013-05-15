using System;
using System.Collections;
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

        private const string LeftWall = " | ";
        private const string RightWall = "| ";
        private const string HorizontalWall = "-";

        private Balloon[,] balloons;
        private int ballonsCount;
        private int poppedBalloonsCount;

        public GameField()
        {
            this.BalloonsMatrix = new Balloon[FieldHeight, FieldWidth];
            this.BallonsCount = FieldHeight * FieldWidth;
            this.poppedBalloonsCount = 0;

            this.InitiliazeGameField();
        }

        public int ClearedCellsCount
        {
            get
            {
                return this.poppedBalloonsCount;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Given value is <= 0!");
                }

                this.poppedBalloonsCount = value;
            }
        }

        public int BallonsCount
        {
            get
            {
                return ballonsCount;
            }

            set
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
                // deep copy  ?
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
                    int randomNumber = RandomNumberGenerator.Instance.Next(0, colors.Length - 1);
                    balloonColor = (Color)colors.GetValue(randomNumber);
                    this.balloons[row, col] = new Balloon(balloonColor);
                }
            }
        }

        /// <summary>
        /// Used to check if a there is a balloon that should fall 
        /// trought if there is an empty space under it, and update 
        /// its position if needed..
        ///</summary>
        public void UpdateBalloonsPositions()
        {
            Queue<Balloon> temp = new Queue<Balloon>();
            
            int row;
            for (int col = 0; col < BalloonsMatrix.GetLength(1); col++)
            {
                //int row = FieldHeight - 1;

                for (row = BalloonsMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    // if balloon is found, push it into the queue
                    if (!this.balloons[row, col].IsPopped)
                    {
                        // before dot
                        temp.Enqueue(this.balloons[row, col]);
                        this.balloons[row, col].Pop();
                    }
                }

                // foreach column, balloons are repositioned from
                // the bottom row to the top row
                // (gravity effect)
                row = BalloonsMatrix.GetLength(0);

                while (temp.Count > 0)
                {
                    this.balloons[--row, col] = (Balloon)temp.Dequeue().Clone();
                }
                temp.Clear();
            }
        }

        /// <summary>
        /// PopsEqualColoredBalloons should check the poped balloon 
        /// neibhours`s colors and pop them if their equal to the 
        /// color of the poped balloon.
        ///</summary>
        public void PopsEqualColoredBalloons(int row, int col, Balloon selectedBalloon)
        {
            bool rowIndexIsInside = (row >= 0) && (row < FieldHeight);
            bool colIndexIsInside = (col >= 0) && (col < FieldWidth);
            bool isEqualColoredBalloon = false;

            if (rowIndexIsInside && colIndexIsInside)
            {
                isEqualColoredBalloon = (this.balloons[row, col].Color == selectedBalloon.Color);
            }


            if (isEqualColoredBalloon)
            {
                if (!this.balloons[row, col].IsPopped)
                {
                    this.balloons[row, col].Pop();

                    this.poppedBalloonsCount++;

                    //Check Up balloon.
                    PopsEqualColoredBalloons(row - 1, col, selectedBalloon);

                    //Check Down balloon.
                    PopsEqualColoredBalloons(row + 1, col, selectedBalloon);

                    //Check Left balloon.
                    PopsEqualColoredBalloons(row, col + 1, selectedBalloon);

                    //Check Right balloon.
                    PopsEqualColoredBalloons(row, col - 1, selectedBalloon);
                }
            }
            else
            {
                this.ballonsCount -= this.poppedBalloonsCount;
                this.poppedBalloonsCount = 0;
                return;
            }
        }

        /// <summary>
        /// Print the Gamefield on the console
        /// </summary>
        /// <param name="balloons"></param>
        public void PrintToConsole()
        {
            Console.ForegroundColor = ConsoleColor.White;

            string horizontalLine = new string(HorizontalWall[0], (FieldWidth * 2) + 1);
            string offset = "   ";

            Console.WriteLine(offset + " 0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine(offset + horizontalLine);

            for (int row = 0; row < FieldHeight; row++)
            {
                Console.Write(row + LeftWall);

                for (int column = 0; column < FieldWidth; column++)
                {
                    Console.ForegroundColor = Utilities.MatchColor(this.balloons[row, column].Color);
                    Console.Write(this.balloons[row, column].GetBalloonChar() + " ");
                }

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write(RightWall);
                Console.WriteLine();
            }

            Console.WriteLine(offset + horizontalLine);
        }
    }
}
