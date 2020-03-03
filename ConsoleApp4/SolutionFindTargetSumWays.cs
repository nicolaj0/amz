public class SolutionFindTargetSumWays
{
    private int[] _nums;
    private int _s;
    private int _res;

    public int FindTargetSumWays(int[] nums, int S)
    {
        _s = S;
        _nums = nums;
        _res = 0;

        helper(0, 0);

        return _res;
    }

    private void helper(int index, int sum)
    {
        if (index == _nums.Length)
        {
            if (sum == _s)
            {
                _res++;
            }
        }
        else
        {
            helper(index + 1, sum + _nums[index]);
            helper(index + 1, sum - _nums[index]);
        }
    }
}