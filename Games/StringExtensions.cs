using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string value, string compare) //.Compares a tring regaurdless of case
        {
            return compare.ToLower() == value.ToLower();
        }

        public static bool equals(this string value, string compare) //.Compares a string but is case sensative
        {
            return compare == value;
        }
    }
}
