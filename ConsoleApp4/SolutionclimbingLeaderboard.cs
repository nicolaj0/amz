using System.Collections.Generic;
using System.Linq;

class SolutionclimbingLeaderboard
{
    private static int[] _alice;
    private static List<int> _res;
    private static Dictionary<int, int> _scores1;

    // Complete the climbingLeaderboard function below.
    public static int[] climbingLeaderboard(int[] scores, int[] alice)
    {
        _scores1 = scores.ToList().GroupBy(r => r).ToDictionary(r => r.Key, v => v.ToList().Count);
        _alice = alice;
        _res = new List<int>();

        helper(0);

        return _res.ToArray();
    }

    private static void helper(int game)
    {
        if (game == _alice.Length) return;

        var score =  _alice[game];

        if (_scores1.ContainsKey(score))
        {
            _scores1[score]++;
        }
        else
        {
            _scores1[score] = 1;
        }

        var rank = _scores1.Keys.OrderByDescending(k=>k).ToList().IndexOf(score);

        // _scores.Insert(i, score);
        _res.Add(rank+1);

        helper(game + 1);
    }
}