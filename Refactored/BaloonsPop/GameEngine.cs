namespace BaloonsPop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class GameEngine
    {
        private int playerMoveCount;
        private GameField gameField;
        private readonly HighScore highScore;
        private string userInput;
        private readonly string[] menuCommands;

        public GameEngine()
        {
            this.gameField = new GameField();
            this.playerMoveCount = 0;
            this.highScore = new HighScore();
            this.userInput = string.Empty;
            this.menuCommands = new string[] { "top", "restart", "exit" };
        }

        public void Run()
        {
            ConsolePrinter.Message(UIMessages.Greetings());
            this.InitializeGame();
            this.GameLoop();
        }

        private void GameLoop()
        {
            while (true)
            {
                // check if the game has ended
                if (!(this.gameField.BallonsCount == 0))
                {
                    do
                    {
                        ConsolePrinter.Message(UIMessages.EnterRowCol());
                        this.userInput = this.ReadConsoleInput();
                    }
                    while (!this.IsCommandValid(this.userInput, this.menuCommands));

                    this.ExecuteMenuCommand(this.userInput);

                    int rowIndex = int.Parse(this.userInput[0].ToString());
                    int colIndex = int.Parse(this.userInput[1].ToString());

                    bool isBalloonPopped = this.gameField.BalloonsMatrix[rowIndex, colIndex].IsPopped;

                    if (!isBalloonPopped)
                    {
                        this.ExecutePopCommand(rowIndex, colIndex);
                        this.DrawField();
                    }
                    else
                    {
                        ConsolePrinter.Message(UIMessages.IllegalMove() + "\n");
                    }
                }
                else
                {
                    this.EndsGame();
                }
            }
        }

        private void ExecutePopCommand(int rowIndex, int colIndex)
        {
            Balloon selectedBalloon = this.gameField.BalloonsMatrix[rowIndex, colIndex];

            this.gameField.PopsEqualColoredBalloons(rowIndex, colIndex, selectedBalloon);
            this.gameField.UpdateBalloonsPositions();

            this.playerMoveCount++;
            this.gameField.BallonsCount -= this.gameField.ClearedCellsCount;
            this.gameField.ClearedCellsCount = 0;
        }

        private bool IsCommandValid(string userInput, string[] commands)
        {
            if (userInput.Length > 1)
            {
                // check if the command is a menu command
                for (int index = 0; index < commands.Length; index++)
                {
                    if (userInput == commands[index])
                    {
                        return true;
                    }
                }

                int rowIndex;
                bool rowIndexIsDigit = int.TryParse(this.userInput.ToString()[0].ToString(), out rowIndex);

                int colIndex;
                bool colIndexIsDigit = int.TryParse(this.userInput.ToString()[1].ToString(), out colIndex);

                if (rowIndexIsDigit && colIndexIsDigit)
                {
                    if (this.AreInRange(rowIndex, colIndex))
                    {
                        return true;
                    }
                }
            }

            ConsolePrinter.Message(UIMessages.InvalidCommand() + "\n");
            return false;
        }

        private void EndsGame()
        {
            ConsolePrinter.Message(UIMessages.Congratulations() + this.playerMoveCount + " moves.");
            ConsolePrinter.Message(UIMessages.PleaseEnterYourName());
            this.userInput = Console.ReadLine();

            this.highScore.AddResult(this.userInput, this.playerMoveCount);
            this.ShowStatistics();

            this.Restart();
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
            this.Run();
        }

        private void DrawField()
        {
            this.gameField.PrintToConsole();
        }

        private string ReadConsoleInput()
        {
            return Console.ReadLine().Replace(" ", string.Empty);
        }

        private void ExecuteMenuCommand(string currentCommand)
        {
            if (currentCommand == "top")
            {
                ConsolePrinter.Message(UIMessages.HighScore() + "\n");
                this.ShowStatistics();
                this.GameLoop();
            }
            else if (currentCommand == "restart")
            {
                Console.Clear();
                this.Restart();
            }
            else if (currentCommand == "exit")
            {
                this.Exit();
            }
        }

        private void InitializeGame()
        {
            this.playerMoveCount = 0;
            this.gameField = new GameField();
            this.DrawField();
            this.userInput = string.Empty;
        }

        private bool AreInRange(int row, int col)
        {
            bool rowIsInRange = (row >= 0) && (row < GameField.FieldHeight);
            bool colIsInRange = (col >= 0) && (col < GameField.FieldWidth);

            if (rowIsInRange && colIsInRange)
            {
                return true;
            }

            return false;
        }

        private void ShowStatistics()
        {
            ConsolePrinter.Message(this.highScore.ToString());
        }
    }
}
