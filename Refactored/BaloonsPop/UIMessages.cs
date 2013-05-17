namespace BaloonsPop
{
    using System.Text;

    public static class UIMessages
    {
        /// <summary>
        /// The initial welcom msg as string.
        /// </summary>
        /// <returns>return string</returns>
        public static string Greetings()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Welcome to “Balloons Pops” game.");
            result.AppendLine("Please try to pop the balloons. ");
            result.Append("Use 'top' to view the top scoreboard, ");
            result.Append("'restart' to start a new game and 'exit' to quit the game.\n");

            return result.ToString();
        }

        /// <summary>
        /// Return a Invalide move msg as a string.
        /// </summary>
        /// <returns>return string</returns>
        public static string InvalidMove()
        {
            return "Invalid move! The row and col should be in the given range.\n";
        }

        /// <summary>
        /// Return a Invalide command msg as a string.
        /// </summary>
        /// <returns>return string</returns>
        public static string InvalidCommand()
        {
            return "Invalid command!\n";
        }

        /// <summary>
        /// Return a "Illegal move msg" as a string.
        /// </summary>
        /// <returns>return string</returns>
        public static string IllegalMove()
        {
            return "Cannot pop missing ballon!\n";
        }

        /// <summary>
        /// Return a "Goodbye msg" as a string.
        /// </summary>
        /// <returns>return string</returns>
        public static string GoodBye()
        {
            return "Good Bye!!!\n";
        }

        /// <summary>
        /// Return a "Enter row col" msg as a string.
        /// </summary>
        /// <returns>return string</returns>
        public static string EnterRowCol()
        {
            return "Enter a row and column: \n";
        }

        /// <summary>
        /// Return a "Congratulation" msg as a string.
        /// </summary>
        /// <returns>return string</returns>
        public static string Congratulations()
        {
            return "Congratulations!!! You popped all balloons in ";
        }

        /// <summary>
        /// Return a "Enter Youre Name" move msg as a string.
        /// </summary>
        /// <returns>return string</returns>
        public static string PleaseEnterYourName()
        {
            return "Please enter your name for the top scoreboard: ";
        }

        /// <summary>
        /// Return a "highScore" msg as a string.
        /// </summary>
        /// <returns>return string</returns>
        public static string HighScore()
        {
            return "HighScore: ";
        }
    }
}
