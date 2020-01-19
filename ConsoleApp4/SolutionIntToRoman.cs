using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionIntToRoman
    {
        Dictionary<int, (char, char?)> _dictionary = new Dictionary<int, (char, char?)>
        {
            {1, ('I', 'V')},
            {2, ('X', 'L')},
            {3, ('C', 'D')},
            {4, ('M', null)},
        };

        public string IntToRoman(int num)
        {
            var res = new List<string>();
            decode(num.ToString(), res);


            return string.Join("", res);
        }

        private void decode(string num, List<string> res)
        {
            if (num == "") return;

            var eee = num.Substring(0, 1);

            var rrr = _dictionary[num.Length];


            var curr = "";
            var nn = Convert.ToInt32(eee);

            if (rrr.Item2 == null)
                curr = new String(rrr.Item1, nn);
            else
            {
                var newxt = _dictionary[num.Length + 1];

                if (nn > 0 && nn <= 3) curr = new String(rrr.Item1, nn);
                else if (nn == 4) curr = new String(new char[] {rrr.Item1, rrr.Item2.Value});
                else if (nn == 5) curr = new String(rrr.Item2.Value, 1);
                else if (nn == 6) curr = new String(new char[] {rrr.Item2.Value, rrr.Item1});
                else if (nn > 6 && nn < 9) curr = new String(rrr.Item2.Value, 1) + new String(rrr.Item1, nn - 5);
                else if (nn == 9) curr = new String(new char[] {rrr.Item1, newxt.Item1});
            }

            res.Add(curr);
            decode(num.Substring(1), res);
        }
    }
}