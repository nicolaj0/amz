namespace ConsoleApp4
{
    public class SolutionSearchTotatingArray {
        private int[] _nums;
        private int _target;

        public int Search(int[] nums, int target)
        {
            _target = target;
            _nums = nums;
            int left = 0, right = nums.Length - 1, pivot=0;

            while (left<=right)
            {
                pivot = left + (right - left) / 2;
                if (nums[left] == nums[right]) return pivot;
                if (nums[left] < nums[right]) 
                    right = pivot - 1;
                else 
                    left = pivot + 1;

            }

            if (target > pivot) return search(pivot, nums.Length);
            return search(0, pivot);

            return -1;
        }
        
        public int search(int left, int right) {
            /*
            Binary search
            */
            while (left <= right) {
                int pivot = (left + right) / 2;
                if (_nums[pivot] == _target)
                    return pivot;
                else {
                    if (_target < _nums[pivot])
                        right = pivot - 1;
                    else
                        left = pivot + 1;
                }
            }
            return -1;
        }
    }
}