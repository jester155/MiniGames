using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class RandomGenerator
    {
            public static Random r = new Random(Environment.TickCount); // Random generator object
    }

    class Parse
    {
        public static int canParse(string q) //Try to parse the string as an integer
        {
            int value;

            int.TryParse(q, out value);
            
            return value;
        }
    }
}
