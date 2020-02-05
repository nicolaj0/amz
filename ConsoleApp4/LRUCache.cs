using System;
using System.Collections.Generic;
using System.Linq;

public class LRUCache
{
    private int _capacity;
    Dictionary<int, (int, DateTime)> _freq = new Dictionary<int, (int, DateTime)>();

    public LRUCache(int capacity)
    {
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (!_freq.ContainsKey(key)) return -1;
        _freq[key] = (_freq[key].Item1, DateTime.Now);

        return _freq[key].Item1;
    }

    public void Put(int key, int value)
    {
        if (!_freq.ContainsKey(key) && _freq.Keys.Count >= _capacity)
        {
            _freq.Remove(_freq.OrderBy(g => g.Value.Item2).FirstOrDefault().Key);
        }

        _freq[key] = (value, DateTime.Now);
    }
}