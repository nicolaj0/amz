using System.Linq;

namespace ConsoleApp4
{
    public class SolutionHighFive
    {
        public int[][] HighFive(int[][] items)
        {
            var res =items.GroupBy(i => i[0]).Select(r => new
            {
                r.Key,
                avarege = (int)r.ToList().Select(f => f[1]).OrderByDescending(g => g).Take(5).Average()
            });

            var array = res.ToArray().Select(r=>new int[]{r.Key,r.avarege}).ToArray();

            return array;
        }
    }
}