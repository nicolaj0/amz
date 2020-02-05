using System.Collections.Generic;

public class TimeMap
{
    /** Initialize your data structure here. */
    Dictionary<string, List<(int, string)>> _map = new Dictionary<string, List<(int, string)>>();

    public TimeMap()
    {
    }

    public void Set(string key, string value, int timestamp)
    {
        if (_map.ContainsKey(key))
        {
            _map[key].Add((timestamp, value));
        }
        else
        {
            _map[key] = new List<(int, string)> {(timestamp, value)};
        }
    }

    public string Get(string key, int timestamp)
    {
        if (!_map.ContainsKey(key)) return "";

        var ditc = _map[key];

        int i = ditc.BinarySearch((timestamp, key), new GFG());

        if (i >= 0)
            return ditc[i].Item2;
        if (i == -1)
            return "";
        return ditc[-i - 2].Item2;
        
    }

    class GFG : IComparer<(int, string)>
    {
        public int Compare((int, string) a, (int, string) b)
        {
            return a.Item1.CompareTo(b.Item1);
        }
    }
}