using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    class Balloon
    {
        static readonly char[] balloone = {'*'};
        static readonly char[] popedBalloone = {'.'};   //white color with char '.'     or      empty string :? 
        static private bool isPop = false;
        
        public  char[]  GetVisualisation()
        {
            if (isPop)
            {
                //this.Color = Color.White;
                return popedBalloone;             //not sure if it's a goot practish to use this
            }
            else
            {
                return balloone;
            }
        }

        //must be used
        public void Pop()
        {
            isPop = true;
        }

        public char Visualisation { get; protected set; }
        public Color Color { get; protected set; }
        public bool IsPop { get; protected set; }
       }
}
