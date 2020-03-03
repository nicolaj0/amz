using System;
using System.Collections.Generic;

class SolutionFindDisappearedNumbers {
    public List<int> FindDisappearedNumbers(int[] nums) {
        
        // Hash table for keeping track of the numbers in the array
        // Note that we can also use a set here since we are not 
        // really concerned with the frequency of numbers.
        var hashTable = new Dictionary<int, Boolean>();
        
        // Add each of the numbers to the hash table
        foreach (var t in nums)
        {
            hashTable[t] = true;
        }
        
        // Response array that would contain the missing numbers
        var result = new List<int>();
        
        // Iterate over the numbers from 1 to N and add all those
        // that don't appear in the hash table. 
        for (int i = 1; i <= nums.Length; i++) {
            if (!hashTable.ContainsKey(i)) {
                result.Add(i);
            }
        }
        
        return result;
    }
}