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
        const int GameFieldHeight = 5;
        const int GameFieldWidth = 10;

        private static int ballonsCount = GameFieldHeight * GameFieldWidth;
        private static int playerMoveCount = 0;
        private static int clearedCellsCount = 0;
        public static string[,] gameField = new string[GameFieldHeight, GameFieldWidth];
        public static StringBuilder userInput = new StringBuilder();
        private static SortedDictionary<int, string> highScores = new SortedDictionary<int, string>();

        public static void Start()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            ballonsCount = GameFieldHeight * GameFieldWidth;
            playerMoveCount = 0;
            clearedCellsCount = 0;

            for (int row = 0; row < GameFieldHeight; row++)
            {
                for (int col = 0; col < GameFieldWidth; col++)
                {
                    gameField[row, col] = RND.GetRandomInt();
                }
            }
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
            GameLogic(userInput);
        }

        public static void GameLogic(StringBuilder userInput)
        {
            PlayGame();
            playerMoveCount++;
            userInput.Clear();
            GameLogic(userInput);
        }

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

        private static void PrintInvalidMoveOrCommand()
        {
            Console.WriteLine("Invalid move or command");
            userInput.Clear();
            GameLogic(userInput);
        }

        private static void InvalidMove()
        {
            Console.WriteLine("Illegal move: cannot pop missing ballon!");
            userInput.Clear();
            GameLogic(userInput);


        }

        private static void ShowStatistics()
        {
            PrintHighSchores();
        }

        private static void Exit()
        {
            Console.WriteLine("Good Bye");
            Thread.Sleep(1000);
            Console.WriteLine(playerMoveCount.ToString());
            Console.WriteLine(ballonsCount.ToString());
            Environment.Exit(0);
        }

        private static void Restart()
        {
            Start();
        }

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

        private static void PrintHighSchores()
        {
            int p = 0;

            Console.WriteLine("Scoreboard:");
            foreach (KeyValuePair<int, string> s in highScores)
            {
                if (p == 4)
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

        private static void ReadCommand()
        {
            string currentCommand = ReadTheIput();

            CommandRead(currentCommand);
        }

        private static void PlayGame()
        {
            int i = -1;
            int j = -1;


            ReadCommand();

            string activeCell;
            userInput.Replace(" ", "");
            try
            {
                i = Int32.Parse(userInput.ToString()) / 10;
                j = Int32.Parse(userInput.ToString()) % 10;
            }
            catch (Exception)
            {
                PrintInvalidMoveOrCommand();
            }

            if (IsLegalMove(i, j))
            {
                activeCell = gameField[i, j];
                clear(i, j, activeCell);
            }
            else
            {
                InvalidMove();
            }

            remove();

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

        private static void clear(int i, int j, string activeCell)
        {
            if ((i >= 0) && (i <= 4) && (j <= 9) && (j >= 0) && (gameField[i, j] == activeCell))
            {
                gameField[i, j] = ".";
                clearedCellsCount++;
                //Up
                clear(i - 1, j, activeCell);
                //Down
                clear(i + 1, j, activeCell);
                //Left
                clear(i, j + 1, activeCell);
                //Right
                clear(i, j - 1, activeCell);
            }
            else
            {
                ballonsCount -= clearedCellsCount;
                clearedCellsCount = 0;
                return;
            }
        }

        private static void remove()
        {
            int i;
            int j;
            Queue<string> temp = new Queue<string>();
            for (j = GameFieldWidth - 1; j >= 0; j--)
            {
                for (i = GameFieldHeight - 1; i >= 0; i--)
                {
                    if (gameField[i, j] != ".")
                    {
                        temp.Enqueue(gameField[i, j]);
                        gameField[i, j] = ".";
                    }
                }
                i = 4;
                while (temp.Count > 0)
                {
                    gameField[i, j] = temp.Dequeue();
                    i--;
                }
                temp.Clear();
            }
        }

        private static bool IsFinished()
        {
            return (ballonsCount == 0);
        }
    }

    public static class RND
    {

        static Random r = new Random();
        public static string GetRandomInt()
        {
            string legalChars = "1234";
            string builder = null;
            builder = legalChars[r.Next(0, legalChars.Length)].ToString();
            return builder;
        }
    }

    public class StartBaloons
    {
        static void Main(string[] args)
        {
            Baloons.Start();
        }
    }
}