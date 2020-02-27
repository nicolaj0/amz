using System.Collections.Generic;
using System.Linq;

public class SolutionIsHappy
{
    public bool IsHappy(int n)
    {

        getNext(1256);
        
        
        var idct = new HashSet<int>();
        while (n > 1)
        {
            var newValue = n.ToString().ToCharArray().Select(r => r.ToString()).Select(int.Parse).Select(r => r * r)
                .Sum();
            if (idct.Contains(newValue)) return false;
            idct.Add(newValue);
            n = newValue;
        }


        return true;
    }
    
    private int getNext(int n) {
        int totalSum = 0;
        var list = new List<int>();
        while (n > 0) {
            int d = n % 10;
            n = n / 10;
            list.Add(d);
        }
        return totalSum;
    }
    
}