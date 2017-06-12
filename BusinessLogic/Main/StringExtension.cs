using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Main
{
    public static class StringExtension
    {
        public static string Normalise(this string input)
        {
            return input.Replace("/", "--");
        }

        public static string Denormalise(this string input)
        {
            return input.Replace("--", "/");
        }
    }
}
