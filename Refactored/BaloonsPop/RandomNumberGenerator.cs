using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    class RandomNumberGenerator
    {
        static Random r = new Random();
        public static string GetRandomInt()
        {
            string legalChars = "1234";
            string builder = null;
            builder = legalChars[r.Next(0, legalChars.Length)].ToString();
            return builder;
        }
    }
}
