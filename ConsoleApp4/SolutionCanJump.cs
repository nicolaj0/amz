public class SolutionCanJump
{
    private int[] _nums;
    private bool _res;

    public bool CanJump(int[] nums)
    {
        _nums = nums;
        _res = false;
        if (nums.Length == 1) return true;

        helper(0);
        return _res;
    }

    private void helper(int index)
    {
        if (index >= _nums.Length-1)
        {
            _res = true;
            return;
        }

        for (var i = index; i <index + _nums[index]; i++)
        {
            helper(i + 1);
        }
    }
}