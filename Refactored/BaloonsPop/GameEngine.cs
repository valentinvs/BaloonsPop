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
        private string command;

        public GameEngine()
        {
            this.gameField = new GameField();
            this.playerMoveCount = 0;
            this.highScore = new HighScore();
            this.command = string.Empty;
        }

        public void Run()
        {
            //this.InitializeGame();
            ConsolePrinter.Message(UIMessages.Greetings());

            while (true)
            {
                this.DrawField();

                // check if the game has ended
                if (!(this.gameField.BallonsCount == 0))
                {
                    ConsolePrinter.Message(UIMessages.EnterRowCol());
                    this.command = this.ReadConsoleInput();
                    this.ParseCommand();
                    this.ExecuteCommand(this.command);

                    int rowIndex = int.Parse(this.command.ToString()[0].ToString());
                    int colIndex = int.Parse(this.command.ToString()[1].ToString());

                    if (this.IsLegalMove(rowIndex, colIndex))
                    {
                        Balloon selectedBalloon = this.gameField.BalloonsMatrix[rowIndex, colIndex];

                        this.gameField.PopsEqualColoredBalloons(rowIndex, colIndex, selectedBalloon);
                        this.gameField.UpdateBalloonsPositions();
                        
                        this.playerMoveCount++;
                        this.gameField.BallonsCount--;
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
                    this.command = this.ReadConsoleInput();

                    this.highScore.AddResult(this.command, this.playerMoveCount);
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
            return this.command.Replace(" ", "");
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
                this.command = this.ReadConsoleInput();
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
            this.command = string.Empty;
        }
    }
}
