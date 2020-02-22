public class SolutionMaxProfit {
    public int MaxProfit(int[] prices)
    {
        if (prices.Length <= 1) return 0;
        int minPrice = int.MaxValue;
        int maxProfit = int.MinValue;

        foreach (var cuPrice in prices)
        {
            if (cuPrice < minPrice) minPrice = cuPrice;

            var curProfit = cuPrice - minPrice;

            if (curProfit > maxProfit) maxProfit = curProfit;
        }

        return maxProfit;

        /*if (prices.Length <= 1) return 0;
        int maxProfit = Int32.MinValue;

        int currProfit = 0;
        for (int i = 0; i < prices.Length -1; i++)
        {
            var cuPrice = prices[i];

            for (int j = i; j < prices.Length; j++)
            {
                var nextPrice = prices[j];
                currProfit = nextPrice - cuPrice;
                if (currProfit > maxProfit) maxProfit = currProfit;
            }
        }

        return maxProfit;*/
    }
}