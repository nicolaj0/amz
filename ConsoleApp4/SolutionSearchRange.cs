using System.Collections.Generic;

public class SolutionSearchRange
{
    private int _rangeLeft = -1;
    private int _rangeRight = -1;

    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0) return new[] {-1, -1};
        var list = new List<int>();

        int left = 0, right = nums.Length-1;

        while (left <= right)
        {
            var pivot  = left + (right - left) / 2;

            if (nums[pivot] < target)
            {
                left = pivot + 1;
            }
            else if (nums[pivot] > target)
            {
                right = pivot - 1;
            }
            else
            {
                _rangeLeft = pivot;
                _rangeRight = pivot;

                while ( _rangeLeft >= 0 && nums[_rangeLeft] == nums[pivot] )
                {
                    _rangeLeft--;
                }


                while (_rangeRight < nums.Length && nums[_rangeRight] == nums[pivot])
                {
                    _rangeRight++;
                }

                _rangeLeft += 1;
                _rangeRight -= 1;

                break;
            }
        }

        list.Add(_rangeLeft);
        list.Add(_rangeRight);

        return list.ToArray();
    }
}