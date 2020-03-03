public class SolutionProductExceptSelf
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var length = nums.Length;
        var left = new int[length];
        var right = new int[length];

        right[length - 1] = 1;
        for (int i = length - 2; i >= 0; i--)
        {
            right[i] = right[i + 1] * nums[i + 1];
        }

        left[0] = 1;
        for (int i = 1; i < length; i++)
        {
            left[i] = left[i - 1] * nums[i - 1];
        }


        var productExceptSelf = new int[length];

        for (int i = 0; i < length; i++)
        {
            productExceptSelf[i] = left[i] * right[i];
        }


        return productExceptSelf;
    }
}