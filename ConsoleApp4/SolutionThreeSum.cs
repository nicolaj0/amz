using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionThreeSum
    {
        private int[] _nums;
        List<IList<int>> outputFinal = new List<IList<int>>();

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            _nums = nums;
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                dict[nums[i]] = i;
            }

            var check = new Dictionary<(int, int, int), bool>();

            for (var i = 0; i < _nums.Length - 1; i++)
            {
                for (var j = i + 1; j < _nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];

                    if (!dict.ContainsKey(-sum)) continue;
                    
                    var z = dict[-sum];
                    if (z == i || z == j) continue;
                    
                    var l = new List<int> {nums[i], nums[j], nums[z]}.OrderBy(r => r).ToList();
                    var tuple = (l[0], l[1], l[2]);
                    if (check.ContainsKey(tuple)) continue;
                    
                    outputFinal.Add(l);
                    check[tuple]= true;
                }
            }

            return outputFinal;
        }
    }
}