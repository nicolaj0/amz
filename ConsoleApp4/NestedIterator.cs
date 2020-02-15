using System;
using System.Collections.Generic;

public class NestedIterator
{
    private IList<NestedInteger> _nestedList;
    private List<int> _list;
    private List<int>.Enumerator _enumerator;

    public NestedIterator(IList<NestedInteger> nestedList)
    {
        _nestedList = nestedList;
        _list = new List<int>();

        Flaten(nestedList);

        _enumerator = _list.GetEnumerator();
    }

    private void Flaten(IList<NestedInteger> nestedList)
    {
        foreach (var nested in nestedList)
        {
            if (nested.IsInteger())
                _list.Add(nested.GetInteger());
            else
            {
                Flaten(nested.GetList());
            }
        }
        Console.WriteLine("ezeee");
        foreach (var res in _list)
        {
            Console.WriteLine(res);
        }
    }

    public bool HasNext()
    {
        return _enumerator.MoveNext();
    }

    public int Next()
    {
        return _enumerator.Current;
    }
    
    public interface NestedInteger
    {
        bool IsInteger();

        int GetInteger();
        IList<NestedInteger> GetList();
    }
}