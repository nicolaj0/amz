using System;

namespace ConsoleApp4
{
    public class SolutionSqrt {
        public int MySqrt(int x)
        {

            int pivot = 0, left = 0, right =x;
            while (left<=right)
            {
                pivot = left + (right - left) / 2;

                var abs = (long)(pivot) * pivot;
                Console.WriteLine(abs);
                if (abs == x) return pivot;
                if (x < abs) 
                    right = pivot-1 ;
                else 
                    left = pivot +1;
            }

            return right;
        }
            
    }
}