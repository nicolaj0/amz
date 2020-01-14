namespace ConsoleApp4
{
    public class SolutionSearchTotatingArray
    {
        private int[] _nums;
        private int _target;

        public int Search(int[] nums, int target)
        {
            _target = target;
            _nums = nums;
            int n = nums.Length;
            if (_nums.Length == 0) return -1;
            if (n == 1)
                return _nums[0] == target ? 0 : -1;
            var rotate_index = Pivot(0, n - 1);

            if (nums[rotate_index] == target)
                return rotate_index;
            // if array is not rotated, search in the entire array
            if (rotate_index == 0)
                return search(0, n - 1);
            if (target < nums[0])
                // search in the right side
                return search(rotate_index, n - 1);
            // search in the left side
            return search(0, rotate_index);
        }

        private int Pivot(int left, int right)
        {
            if (_nums[left] < _nums[right])
                return 0;

            while (left <= right)
            {
                int pivot = (left + right) / 2;
                if (_nums[pivot] > _nums[pivot + 1])
                    return pivot + 1;
                if (_nums[pivot] < _nums[left])
                    right = pivot - 1;
                else
                    left = pivot + 1;
            }

            return 0;
        }

        public int search(int left, int right)
        {
            /*
            Binary search
            */
            while (left <= right)
            {
                int pivot = (left + right) / 2;
                if (_nums[pivot] == _target)
                    return pivot;
                if (_target < _nums[pivot])
                    right = pivot - 1;
                else
                    left = pivot + 1;
            }

            return -1;
        }
    }
}