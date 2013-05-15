using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public class Balloon : ICloneable
    {
        readonly char notPoppedBallooneChar = 'O';
        readonly char poppedBallooneChar = ' ';   //white color with char '.'     or      empty string :? 

        public Balloon(Color color)
        {
            this.Color = color;
            this.IsPopped = false;
        }

        public char GetBalloonChar()
        {
            if (this.IsPopped)
            {
                //this.Color = Color.White;
                return this.poppedBallooneChar;             //not sure if it's a goot practish to use this
            }
            else
            {
                return this.notPoppedBallooneChar;
            }
        }

        //must be used
        public void Pop()
        {
            this.IsPopped = true;
        }

        public Balloon Clone()
        {
            Balloon clone = new Balloon(this.Color);
            
            return clone;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public char Visualisation { get; private set; }
        public Color Color { get; private set; }
        public bool IsPopped { get; private set; }
    }
}
