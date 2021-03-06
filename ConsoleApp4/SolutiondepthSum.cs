﻿using System.Collections.Generic;

public class SolutiondepthSum
{
    public interface NestedInteger
    {
        // Constructor initializes an empty nested list.

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value);

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni);

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }
    public int depthSum(List<NestedInteger> nestedList) {
        return depthSum(nestedList, 1);
    }
    
    public int depthSum(IList<NestedInteger> list, int depth) {
        int sum = 0;
        foreach (var n in list)
        {
            if (n.IsInteger()) {
                sum += n.GetInteger() * depth;
            } else {
                sum += depthSum(n.GetList(), depth + 1);
            }
        }
      
        return sum;
    }
}