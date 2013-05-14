using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaloonsPop
{
    class GameEngine
    {
        //gameEngine.cs
        private static int playerMoveCount = 0;


        // gameEngine.cs
        private static bool IsLegalMove(GameField gameField, int row, int col)
        {
            //if ((row < 0) || (col < 0) ||
            //    (col >= gameField.BalloonsMatrix.GetLength(1)) ||
            //    (row >= gameField.BalloonsMatrix.GetLength(0)))
            //{
            //    return false;
            //}
            //else if (gameField.BalloonsMatrix[row,col].IsPop)
            //{
            //    return false;
            //}

            return true;
        }

        private static void ShowStatistics()
        {
            // PrintHighSchores();
        }

        private static void Exit()
        {
            //Console.WriteLine("Good Bye");
            //Thread.Sleep(1000);
            //Console.WriteLine(playerMoveCount.ToString());
            //Console.WriteLine(BallonsCount.ToString());
            //Environment.Exit(0);
        }

        // gameEngine.cs
        private static void Restart()
        {
           // InitializeGame();
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

       

        // gameEngine.cs ?
        //private static void ReadCommand()
        //{
        //    string currentCommand = ReadTheIput();

        //    CommandRead(currentCommand);
        //}

        // gameEngine.cs / parser.cs
        //private static void PlayGame()
        //{
        //    try
        //    {
        //        ReadCommand();

        //        userInput.Replace(" ", "");

        //        // input: 5 7 => 57 => 57/10 = 5 => 57%10 => 7
        //        int i = int.Parse(userInput.ToString()[0].ToString());
        //        int j = int.Parse(userInput.ToString()[1].ToString());

        //        // check if the move is legal
        //        if (IsLegalMove(i, j))
        //        {
        //            // activeCell = user ballon choice
        //            string selectedBalloon = gameField[i, j];
        //            PopsEqualColoredBalloons(i, j, selectedBalloon);
        //            playerMoveCount++;
        //        }
        //        else
        //        {
        //            // print UIMessages.error bocka6 tam kydeto nqma balon4e
        //            InvalidMove();
        //        }

        //        // TODO: update Ballons positions (gravity effect)
        //        // TODO: redrawGameField();
        //        // TODO: recursive call for endless loop
        //    }
        //    catch (FormatException exc)
        //    {
        //        Console.WriteLine("pesho si vkaral");
        //        // print UIMessage.error napisal si Pesho != integer
        //    }
        //    catch (ArgumentOutOfRangeException exc)
        //    {
        //        Console.WriteLine("izlqzal si ot matricata");
        //        // print UIMessages.error out of range
        //    }
        //}

        // gameEngine.cs -> switch eventualy (switch added down)
        //private static void CommandRead(string currentCommand)
        //{
        //    if (currentCommand == "")
        //    {
        //        PrintInvalidMoveOrCommand();
        //    }

        //    if (currentCommand == "top")
        //    {
        //        ShowStatistics();
        //        userInput.Clear();
        //        ReadCommand();
        //    }

        //    if (currentCommand == "restart")
        //    {
        //        userInput.Clear();
        //        Restart();
        //    }

        //    if (currentCommand == "exit")
        //    {
        //        Exit();
        //    }
        //}

        /// <summary>
        /// Executes a command depending on user input.
        ///</summary>
        // CommandRead as switch:
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
        //private static bool IsFinished()
        //{
        //    return (ballonsCount == 0);
        //}

        // gameEngine.cs
        public static StringBuilder userInput = new StringBuilder();

        // gameEngine.cs
        private static int clearedCellsCount = 0;

        // gameEngine.cs -> initialize() rename
        public static void InitializeGame()
        {
            // UIMessage.Greetings
            Console.WriteLine();

            // gameField.Initialize()
            //playerMoveCount = 0;

            //InitiliazeGameField();

            // gameEngine.cs ???
            GameEngineMethod(userInput);
        }

        // gameEngine.cs
        public static void GameEngineMethod(StringBuilder userInput)
        {
            //PlayGame();
            userInput.Clear();
            GameEngineMethod(userInput);
        }

    }
}
