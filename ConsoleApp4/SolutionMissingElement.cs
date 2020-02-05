public class SolutionMissingElement
{
    private int[] _nums;
    private int _nb;

    public int MissingElement(int[] nums, int k)
    {
        _nums = nums;
        int left = 0, right = nums.Length - 1, pivot = 0;
        var current = 0;

        while (left <= right)
        {
            pivot = (left + right) / 2;
            _nb = NbOfMissingUntil(pivot);


            if (_nb < k)
            {
                left = pivot + 1;
            }
            else
            {
                right = pivot - 1;
            }
        }

        return nums[left - 1] + k - NbOfMissingUntil(left - 1);
    }


    public int NbOfMissingUntil(int x)
    {
        return (_nums[x] - _nums[0]) - (x);
    }
}