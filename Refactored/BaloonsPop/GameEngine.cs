using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public class GameEngine
    {
        private int playerMoveCount;
        private GameField gameField;
        private HighScore highScore;
        private string userInput;

        public GameEngine()
        {
            this.gameField = new GameField();
            this.playerMoveCount = 0;
            this.highScore = new HighScore();
            this.userInput = string.Empty;
        }

        public void Run()
        {
            ConsolePrinter.Message(UIMessages.Greetings());

            while (true)
            {
                this.DrawField();

                // check if the game has ended
                if (!(this.gameField.BallonsCount == 0))
                {
                    ConsolePrinter.Message(UIMessages.EnterRowCol());
                    this.userInput = this.ReadConsoleInput();
                    this.ParseCommand();
                    this.ExecuteCommand(this.userInput);

                    while (this.userInput.Length<2)
                    {
                        ConsolePrinter.Message(UIMessages.InvalidCommand()+"\n");
                        ConsolePrinter.Message(UIMessages.EnterRowCol());
                        this.userInput = this.ReadConsoleInput();
                    }

                    int rowIndex = int.Parse(this.userInput.ToString()[0].ToString());
                    int colIndex = int.Parse(this.userInput.ToString()[1].ToString());

                    if (this.IsLegalMove(rowIndex, colIndex))
                    {
                        Balloon selectedBalloon = this.gameField.BalloonsMatrix[rowIndex, colIndex];

                        this.gameField.PopsEqualColoredBalloons(rowIndex, colIndex, selectedBalloon);
                        this.gameField.UpdateBalloonsPositions();
                        
                        this.playerMoveCount++;
                        this.gameField.BallonsCount -= this.gameField.ClearedCellsCount;
                        this.gameField.ClearedCellsCount = 0;
                    }
                    else
                    {
                        ConsolePrinter.Message(UIMessages.InvalidMove());
                    }
                }
                else
                {
                    ConsolePrinter.Message(UIMessages.Congratulations() + this.playerMoveCount + " moves.");
                    ConsolePrinter.Message(UIMessages.PleaseEnterYourName());
                    this.userInput = this.ReadConsoleInput();

                    this.highScore.AddResult(this.userInput, this.playerMoveCount);
                    this.ShowStatistics();

                    this.Run();
                }
            }
        }

        private bool IsLegalMove(int row, int col)
        {
            if ((row >= 0) || (col >= 0) ||
                (col < GameField.FieldWidth) ||
                (row < GameField.FieldHeight))
            {
                return true;
            }
            else if (!this.gameField.BalloonsMatrix[row, col].IsPopped)
            {
                return true;
            }

            return false;
        }

        private void ShowStatistics()
        {
            ConsolePrinter.Message(this.highScore.ToString());
        }

        private void Exit()
        {
            ConsolePrinter.Message(UIMessages.GoodBye());
            ConsolePrinter.Message("\nmoves: " + this.playerMoveCount.ToString());
            ConsolePrinter.Message("\nballoons left: " + (this.gameField.BallonsCount - this.gameField.ClearedCellsCount).ToString() + "\n");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        private void Restart()
        {
            this.InitializeGame();
            this.Run();
        }

        private void DrawField()
        {
            this.gameField.PrintToConsole();
        }

        private string ParseCommand()
        {
            return this.userInput.Replace(" ", "");
        }

        private string ReadConsoleInput()
        {
            return Console.ReadLine().Replace(" ", "");
        }

        private void ExecuteCommand(string currentCommand)
        {
            if (currentCommand == "top")
            {
                this.ShowStatistics();
                this.userInput = this.ReadConsoleInput();
            }
            else if (currentCommand == "restart")
            {
                this.Restart();
            }
            else if (currentCommand == "exit")
            {
                Exit();
            }
        }

        private void InitializeGame()
        {
            Console.Clear();
            this.playerMoveCount = 0;
            this.gameField = new GameField();
            this.userInput = string.Empty;
        }
    }
}
