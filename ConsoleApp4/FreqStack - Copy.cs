using System.Collections.Generic;

namespace ConsoleApp4
{
    class FreqStack
    {
        Dictionary<int, int> freq;
        Dictionary<int, Stack<int>> group;
        int maxfreq;

        public FreqStack()
        {
            freq = new Dictionary<int, int>();
            group = new Dictionary<int, Stack<int>>();
            maxfreq = 0;
        }

        public void Push(int x)
        {
            int f = freq.GetValueOrDefault(x, 0) + 1;
            freq[x]=  f;
            if (f > maxfreq)
                maxfreq = f;

            if (!group.ContainsKey(f))
            {
                group[f] = new Stack<int>();
            }
            group[f].Push(x);
        }

        public int Pop()
        {
            int x = group[maxfreq].Pop();
            freq[x] =  freq[x] - 1;
            if (group[maxfreq].Count == 0)
                maxfreq--;
            return x;
        }
    }
}