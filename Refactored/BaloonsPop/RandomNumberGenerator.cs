using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop
{
    public class RandomNumberGenerator
    {

        private static readonly Random RNGInstance;

        static RandomNumberGenerator()
        {
            RNGInstance = new Random();
        }

        private RandomNumberGenerator()
        {
        }

        public static Random Instance
        {
            get
            {
                return RNGInstance;
            }
        }
    }
}
