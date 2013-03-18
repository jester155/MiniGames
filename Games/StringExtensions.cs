using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string value, string compare)
        {
            return (compare.ToLower() == value.ToLower());
        }
    }
}
