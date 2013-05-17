using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public static class ColorUtilities
    {
        /// <summary>
        /// Convert ColorEnum to ConsoleColor color.
        /// </summary>
        /// <param name="color"></param>
        /// <returns>ConsoleColor</returns>
        public static ConsoleColor MatchColor(ColorEnum color)
        {
            ConsoleColor matchColor;

            switch (color)
            {
                case ColorEnum.Blue:
                    matchColor = ConsoleColor.Blue;
                    break;
                case ColorEnum.Green:
                    matchColor = ConsoleColor.Green;
                    break;
                case ColorEnum.Red:
                    matchColor = ConsoleColor.Red;
                    break;
                case ColorEnum.Yellow:
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
