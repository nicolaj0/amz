using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionDecodeVariations
    {
        private List<char> _digits;
        private int _length;
        private int _res;

        public int Decode(string num)
        {
            _digits = num.ToCharArray()
                .ToList();
            _res = 0;

            _length = _digits.Count();

            //backtrack(0, new LinkedList<char>());

            var hits = new List<string>();
            backtrack2( num,"", hits, 0);

            return hits.Count;
        }
        

        private char? GetCharForNumber(string i)
        {
            var ee  = Convert.ToInt32(i);
            return ee > 0 && ee < 27 ? ((char)(ee + 'A' - 1)) : (char?) null;
        }

        private void backtrack2(string num, string cur, List<string> hits, int numCharUsed)
        {
            if (numCharUsed == _length)
            {
                hits.Add(cur);
                Console.WriteLine(cur);
                return;
            }


            if (numCharUsed < _length - 1)
            {
                var int32 = num.Substring(0,2);
                var charr = GetCharForNumber(int32);
                if (charr !=null)
                {
                    backtrack2(num.Substring(2), cur + charr, hits, numCharUsed + 2);
                }
            }
            backtrack2(num.Substring(1), cur + GetCharForNumber(num.Substring(0,1)), hits, numCharUsed + 1);

        }

        private void backtrack(int level, LinkedList<char> linkedList)
        {
            if (linkedList.Count == _length)
            {
                _res++;
                Console.WriteLine(new string(linkedList.ToArray()));
                return;
            }

            if (level < _length - 1)
            {
                var int32 = Convert.ToInt32(string.Concat(_digits[level], _digits[level + 1]));

                if (int32 <= 26)
                {
                    linkedList.AddLast(_digits[level]);
                    linkedList.AddLast(_digits[level + 1]);
                    backtrack(level + 2, linkedList);
                    linkedList.RemoveLast();
                    linkedList.RemoveLast();
                }
            }

            linkedList.AddLast(_digits[level]);
            backtrack(level + 1, linkedList);
            linkedList.RemoveLast();
        }


        

        /*public class Solution {
       public string IntToRoman(int num)
       {
           var difits = num.ToString().Select(Convert.ToInt32).ToArray().Reverse().ToList();
           int k = 0;
           var queue = new Queue<char>();
           
           for (int i = 0; i < difits.Count; i++)
           {
               var curr = "";
               
               if (k == 0)
               {
                   switch (i)
                   {
                       case 1:
                           curr = "I";
                           break;
                       case 2:
                           curr = "II";
                           break;
                       case 3:
                           curr = "III";
                           break;
                   }
               }

               k++;
               queue.Enqueue(curr);
           }
       }
   }
   */
    }
}