using System.Collections.Generic;
using System.Linq;

public class SolutionCoinChange
{
    private int _amount;
    private int min =int.MaxValue;
    private int[] _coins;

    public int CoinChange(int[] coins, int amount)
    {
        _coins = coins;
        _amount = amount;
        if (amount == 0) return 0;

        backtrack(0, new LinkedList<long>());

        return min == int.MaxValue ? -1 : min;
    }

    private void backtrack(int start, LinkedList<long> linkedList)
    {
        var currentSum = linkedList.Sum();

        if (currentSum == _amount)
        {
            if (linkedList.Count < min)
            {
                min = linkedList.Count;
            }
        }
        else if (currentSum < _amount)
        {
            for (int j = start; j < _coins.Length; j++)
            {
                linkedList.AddLast(_coins[j]);
                backtrack(j, linkedList);
                linkedList.RemoveLast();
            }
        }

        
    }
}