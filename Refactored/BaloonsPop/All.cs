using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public class All
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
            InitializeGame();
        }

        // gameEngine.cs
        private static string ReadTheIput()
        {
            userInput.Append(Console.ReadLine());

            // this check should be outside the method
            //if (!IsFinished())
            //{
            //    Console.Write("Enter a row and column: ");
            //    userInput.Append(Console.ReadLine());
            //}
            //else
            //{
            //    Console.Write("opal;aaaaaaaa! You popped all baloons in " + playerMoveCount + " moves."
            //                     + "Please enter your name for the top scoreboard:");
            //    userInput.Append(Console.ReadLine());
            //    highScores.Add(playerMoveCount, userInput.ToString());
            //    PrintHighSchores();
            //    userInput.Clear();
            //    InitializeGame();
            //}

            return userInput.ToString();
        }

        // gameEngine.cs
        private static void PrintHighSchores()
        {
            // TOP 5 players
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
            try
            {
                ReadCommand();

                userInput.Replace(" ", "");

                // input: 5 7 => 57 => 57/10 = 5 => 57%10 => 7
                int i = int.Parse(userInput.ToString()[0].ToString());
                int j = int.Parse(userInput.ToString()[1].ToString());

                // check if the move is legal
                if (IsLegalMove(i, j))
                {
                    // activeCell = user ballon choice
                    string selectedBalloon = gameField[i, j];
                    PopsEqualColoredBalloons(i, j, selectedBalloon);
                    playerMoveCount++;
                }
                else
                {
                    // print UIMessages.error bocka6 tam kydeto nqma balon4e
                    InvalidMove();
                }

                // TODO: update Ballons positions (gravity effect)
                // TODO: redrawGameField();
                // TODO: recursive call for endless loop
            }
            catch (FormatException exc)
            {
                Console.WriteLine("pesho si vkaral");
                // print UIMessage.error napisal si Pesho != integer
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine("izlqzal si ot matricata");
                // print UIMessages.error out of range
            }
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

        // CommandRead as switch

        //private static void switch(string currentCommand)
        //{
        
        //    case "":
        //        PrintInvalidMoveOrCommand();
        //        break;
        //    case "top":
        //        ShowStatistics();
        //        userInput.Clear();
        //        ReadCommand();
        //        break;
        //    case "restart":
        //        userInput.Clear();
        //        Restart();
        //        break;
        //    case "exit":
        //        Exit();
        //        break;
        //    default;
        //}

        // gameEngine.cs
        private static bool IsFinished()
        {
            return (ballonsCount == 0);
        }

        // gameEngine.cs
        public static StringBuilder userInput = new StringBuilder();

        // gameEngine.cs
        private static int clearedCellsCount = 0;

        // gameEngine.cs -> initialize() rename
        public static void InitializeGame()
        {
            // UIMessage.Greetings
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            // gameField.Initialize()
            //playerMoveCount = 0;

            InitiliazeGameField();

            // gameEngine.cs ???
            GameEngine(userInput);
        }

        // gameEngine.cs
        public static void GameEngine(StringBuilder userInput)
        {
            PlayGame();
            userInput.Clear();
            GameEngine(userInput);
        }

    }

    // gameEngine.cs
    public class StartBaloons
    {
        static void Main(string[] args)
        {
            All.InitializeGame();
        }
    }
}