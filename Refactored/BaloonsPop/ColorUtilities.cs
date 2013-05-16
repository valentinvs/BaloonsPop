using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public static class ColorUtilities
    {
        public static ConsoleColor MatchColor(Color color)
        {
            ConsoleColor matchColor;

            switch (color)
            {
                case Color.Blue:
                    matchColor = ConsoleColor.Blue;
                    break;
                case Color.Green:
                    matchColor = ConsoleColor.Green;
                    break;
                case Color.Red:
                    matchColor = ConsoleColor.Red;
                    break;
                case Color.Yellow:
                    matchColor = ConsoleColor.Yellow;
                    break;
                default:
                    matchColor = ConsoleColor.White;
                    break;
            }

            return matchColor;
        }
    }
}
