using System;

namespace ConsoleApp4
{
    public class SolutionSearchMatrix
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            return binarySearch(matrix, (0, 0), (matrix.GetUpperBound(0), matrix.GetUpperBound(1)), target);
        }


        static bool binarySearch(int[,] arr, (int, int) topleft,
            (int, int) bottomright, int x)
        {
            if (bottomright.Item1
                >= topleft.Item1 && bottomright.Item2 >= topleft.Item2)
            {
                var mid = ValueTuple.Create(
                    topleft.Item1 + (bottomright.Item1 - topleft.Item1) / 2,
                    topleft.Item2 + (bottomright.Item2 - topleft.Item2) / 2);


                if (arr[mid.Item1, mid.Item2] == x)
                    return true;


                var shiftx = 1;
                var shifty = bottomright.Item2 != topleft.Item2 ? 1 : 0;

                if (arr[mid.Item1, mid.Item2] > x)
                {
                    return binarySearch(arr,
                        topleft,
                        (mid.Item1 - shiftx, mid.Item2 - shifty), x);
                }
                    
                return binarySearch(arr,
                    ((mid.Item1 + shiftx), (mid.Item2 + shifty)),
                    bottomright, x);
            }


            return false;
        }
    }
}