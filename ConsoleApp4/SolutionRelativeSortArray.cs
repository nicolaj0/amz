using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionRelativeSortArray
    {
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            var hmap = new Dictionary<int, int>();

            for (int i = 0; i < arr2.Length; i++)
            {
                hmap[arr2[i]] = i;
            }


            int n = arr1.Length;

            for (int i = 0; i < arr1.Length; i++)
            {
                int min_idx = i;

                for (int j = i + 1; j < n; j++)
                {

                    var cond1 = hmap.ContainsKey(arr1[j]) && !hmap.ContainsKey(arr1[min_idx]);
                    var cond2 = hmap.ContainsKey(arr1[j]) && hmap.ContainsKey(arr1[min_idx]) && hmap[arr1[j]] < hmap[arr1[min_idx]];
                    var cond3 = !hmap.ContainsKey(arr1[j]) && !hmap.ContainsKey(arr1[min_idx]) &&
                                arr1[j] < arr1[min_idx];
                        
                    if (cond1 || cond2 || cond3)
                        min_idx = j;
                }

                // Swap the found minimum element with the first 
                // element 
                int temp = arr1[min_idx];
                arr1[min_idx] = arr1[i];
                arr1[i] = temp;
            }


            return arr1;
        }
    }
}