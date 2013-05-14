using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaloonsPop
{
    class All
    {
    }

    public class Baloons
    {
        //gameEngine.cs
        private static int playerMoveCount = 0;

        // gameEngine.cs
        private static bool IsLegalMove(int row, int col)
        {
            if ((row < 0) || (col < 0) ||
                (col > GameFieldWidth - 1) ||
                (row > GameFieldHeight - 1))
            {
                return false;
            }
            else if (gameField[row, col] == ".")
            {
                return false;
            }

            return true;
        }

        // gameEngine ???
        private static void ShowStatistics()
        {
            PrintHighSchores();
        }

        // gameEngine.cs
        private static void Exit()
        {
            Console.WriteLine("Good Bye");
            Thread.Sleep(1000);
            Console.WriteLine(playerMoveCount.ToString());
            Console.WriteLine(ballonsCount.ToString());
            Environment.Exit(0);
        }

        // gameEngine.cs
        private static void Restart()
        {
            Start();
        }

        // gameEngine.cs
        private static string ReadTheIput()
        {
            if (!IsFinished())
            {
                Console.Write("Enter a row and column: ");
                userInput.Append(Console.ReadLine());
            }
            else
            {
                Console.Write("opal;aaaaaaaa! You popped all baloons in " + playerMoveCount + " moves."
                                 + "Please enter your name for the top scoreboard:");
                userInput.Append(Console.ReadLine());
                highScores.Add(playerMoveCount, userInput.ToString());
                PrintHighSchores();
                userInput.Clear();
                Start();
            }

            return userInput.ToString();
        }

        // gameEngine.cs
        private static void PrintHighSchores()
        {
            // TOP 4 players
            int p = 0;

            Console.WriteLine("Scoreboard:");
            foreach (KeyValuePair<int, string> s in highScores)
            {
                if (p > 4)
                {
                    break;
                }
                else
                {
                    p++;
                    Console.WriteLine("{0}. {1} --> {2} moves", p, s.Value, s.Key);
                }
            }
        }

        // gameEngine.cs ?
        private static void ReadCommand()
        {
            string currentCommand = ReadTheIput();

            CommandRead(currentCommand);
        }

        // gameEngine.cs / parser.cs
        private static void PlayGame()
        {
            int i = -1;
            int j = -1;


            ReadCommand();

            string activeCell;
            userInput.Replace(" ", "");
            try
            {
                // input: 5 7 => 57 => 57/10 = 5 => 57%10 => 7
                //i = Int32.Parse(userInput.ToString()) / 10;
                //j = Int32.Parse(userInput.ToString()) % 10;

                i = int.Parse(userInput.ToString()[0].ToString());
                j = int.Parse(userInput.ToString()[1].ToString());
            }
            catch (Exception)
            {
                PrintInvalidMoveOrCommand();
            }

            if (IsLegalMove(i, j))
            {
                // activeCell = user ballon choice
                activeCell = gameField[i, j];
                PopsEqualColoredBalloons(i, j, activeCell);
            }
            else
            {
                InvalidMove();
            }

            // to rename -> gravity effect -> gameField.cs
            UpdateBalloonsPositions();

            // TODO: refactor to a new method DrawField()
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int ii = 0; ii < GameFieldHeight; ii++)
            {
                Console.Write(ii + " | ");

                for (int jj = 0; jj < GameFieldWidth; jj++)
                {
                    Console.Write(gameField[ii, jj] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");

            // ---------------
        }

        // gameEngine.cs -> switch eventualy
        private static void CommandRead(string currentCommand)
        {
            if (currentCommand == "")
            {
                PrintInvalidMoveOrCommand();
            }

            if (currentCommand == "top")
            {
                ShowStatistics();
                userInput.Clear();
                ReadCommand();
            }

            if (currentCommand == "restart")
            {
                userInput.Clear();
                Restart();
            }

            if (currentCommand == "exit")
            {
                Exit();
            }
        }

        // gameEngine.cs
        private static bool IsFinished()
        {
            return (ballonsCount == 0);
        }

        // gameEngine.cs
        private static SortedDictionary<int, string> highScores = new SortedDictionary<int, string>();

        // gameEngine.cs
        public static StringBuilder userInput = new StringBuilder();

        // gameEngine.cs
        private static int clearedCellsCount = 0;

        // gameEngine.cs -> initialize() rename
        public static void Start()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            //ballonsCount = GameFieldHeight * GameFieldWidth;
            //playerMoveCount = 0;
            //clearedCellsCount = 0;

            // gameField set method
            InitiliazeGameField();

            // gameEngine.cs ???
            GameEngine(userInput);
        }

        // gameEngine.cs
        public static void GameEngine(StringBuilder userInput)
        {
            PlayGame();
            playerMoveCount++;
            userInput.Clear();
            GameEngine(userInput);
        }
        
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

    // utils.cs
    public static class RND
    {

    }

    // gameEngine.cs
    public class StartBaloons
    {
        static void Main(string[] args)
        {
            Baloons.Start();
        }
    }
}