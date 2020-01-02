using System;

namespace ConsoleApp4
{
    public class SolutionGcdOfStrings
    {
        public string GcdOfStrings(string a, string b)
        {
            /*if (!a.ToCharArray().Intersect(b.ToCharArray()).Any())
                return string.Empty;*/

            return gcd(a, b);


        }

        private string gcd(string a, string b)
        {
            if (a.Length == 0)
                return b;
            
            if (a.Replace(b,"") == a && b.Replace(a,"") == b ) return "";

            var replace = b.Replace(a, "");

            Console.WriteLine(replace);

            return gcd(replace, a);
        }
    }
}