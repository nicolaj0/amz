public class SolutionSortColors {
    public void SortColors(int[] nums)
    {
        Sort(nums);

    }
    public static int[] Sort(int[] array) 
    { 
        for (int i = 0; i < array.Length; i++) 
        { 
            bool isAnyChange = false; 
            for (int j = 0; j < array.Length - 1; j++) 
            { 
                if (Compare(array[j],array[j + 1]) > 0) 
                { 
                    isAnyChange = true; 
                    Swap(array, j, j + 1); 
                } 
            } 
 
            if (!isAnyChange) 
            { 
                break; 
            } 
        } 
        return array; 
    }

    private static int Compare(int p0, int p1)  
    {
        if (p0 == 0 && p1 == 1) return -1;
        if (p0 == 0 && p1 == 2) return -1;
        if (p0 == 1 && p1 == 2) return -1;
        if (p0 == p1) return 0;
        return 1;

    }

    private static void Swap<T>(T[] array, int first, int second) 
    { 
        T temp = array[first]; 
        array[first] = array[second]; 
        array[second] = temp; 
    } 
}