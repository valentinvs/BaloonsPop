namespace BaloonsPop
{
    using System;

    /// <summary>
    /// Represents a chess piece.
    /// </summary>
    public class Balloon : ICloneable
    {
        readonly char notPoppedBallooneChar = 'O';
        readonly char poppedBallooneChar = ' ';   //white color with char '.'     or      empty string :? 

        /// <summary>Initializes a new instance of the <see cref="Balloon"/> class.
        /// </summary>
        /// <param name="color">The balloon color.</param>
        public Balloon(ColorEnum color)
        {
            this.Color = color;
            this.IsPopped = false;
        }

        /// <summary>Char of the bubble.
        /// </summary>
        /// <returns>If balloon IsPop return ' ',
        /// else 'O' </returns>
        public char GetBalloonChar()
        {
            if (this.IsPopped)
            {
                return this.poppedBallooneChar;             //not sure if it's a goot practish to use this
            }
            else
            {
                return this.notPoppedBallooneChar;
            }
        }

        /// <summary>
        /// Pop balloons and from there on the bubble is
        /// treated as leaky and "Getbaloonchar" 
        /// returns empty charm.
        /// </summary>
        public void Pop()
        {
            this.IsPopped = true;
        }

        /// <summary>
        /// Performs a deep copy of the <see cref="Balloon"/> object.
        /// </summary>
        /// <returns>A copy of the object being cloned.</returns>
        public object Clone()
        {
            Balloon clone = new Balloon(this.Color);
            
            return clone;
        }

        public char Visualisation { get; private set; }
        public ColorEnum Color { get; private set; }

        /// <summary>
        /// Check if the balloon is popped and returns a boolean value.
        /// </summary>
        /// <returns>Return whether the balloon is Poped .</returns>
        public bool IsPopped { get; private set; }
    }
}
