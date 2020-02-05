using System;
using System.Collections.Generic;

public class MedianFinder
{
    private List<int> _list;

    public MedianFinder()
    {
        _list = new List<int>();
    }

    public void AddNum(int num)
    {
        _list.Add(num);
        Array.Sort(_list.ToArray());
    }

    public double FindMedian()
    {
        if (_list.Count % 2 != 0) return _list[(_list.Count - 1) / 2];

        var i = _list[_list.Count / 2 - 1];
        var l = _list[_list.Count / 2];
        return (l + i) / 2.0;
    }
}