namespace ConsoleApp4
{
    public class sdf
    {
           /*var res = new SolutionMergeTwoLists().MergeTwoLists(
            new SolutionMergeTwoLists.ListNode(2),
            new SolutionMergeTwoLists.ListNode(1));
        /*new ListNode(2) {next = new ListNode(2) {next = new ListNode(4)}},
        new ListNode(1) {next = new ListNode(3) {next = new ListNode(4)}});#1#
        Console.WriteLine(res);*/

        /*
        var res = new Solution().LongestPalindrome('abb');
        Console.WriteLine(res);*/

        /*var res = new Solution().IsValid('{[]}');
        Console.WriteLine(res);*/

        /*var res = new Solution().RemoveNthFromEnd(
            new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3) {next = new ListNode(4) {next = new ListNode(5)}}
                }
            },
            2);*/

        /*var res = new Solution().RemoveNthFromEnd(
            new ListNode(1){ next = new ListNode(2)},
            2);

        Console.WriteLine(res);*/


        // var res = new Solution().SearchMatrix( new int[,] {{1, 4, 7, 11}, {2, 5, 8, 12}, {3, 6, 9, 16}, {10, 13, 14, 17}}, 9);
        /*var res = new Solution().SearchMatrix(new int[,]{{1,4},{2,5}}, 2);
        // var res = new Solution().SearchMatrix(new int[,] {{-1, 3}}, 3);
        //var res = new Solution().SearchMatrix(new int[,] {{ -5}}, -5);
        //var res = new Solution().SearchMatrix(new int[,] {{ 1,1}}, 2);
        // var res = new Solution().SearchMatrix(new int[,] {{1, 3, 5}}, 1);
        Console.WriteLine(res);*/


        /*new Solution().Solve(new char[][]
        {
            new[] {'X', 'X', 'X', 'X'},
            new[] {'X', 'O', 'O', 'X'},
            new[] {'X', 'O', 'O', 'X'},
            new[] {'X', 'O', 'X', 'X'},
            new[] {'X', 'O', 'X', 'X'},
        });*/


        /*var res = new Solution().CountCharacters(new[] {'cat', 'bt', 'hat', 'tree'}, 'atach');
        Console.WriteLine(res);*/

        //var res = new Solution2().combine(2, 6, 7);
        //ar res = new  Solution2().combine(1, 6, 3);
        //var res = new Solution().NumRollsToTarget(2, 5, 10);
        //Console.WriteLine(res);

        // var res = new Solution2().combine(4, 2);

        /*var res = new Solution().IsRectangleOverlap(new[] {0, 0, 2, 2}, new[] {1, 1, 3, 3});
        //var res = new Solution().IsRectangleOverlap(new[] {0, 0, 1, 1}, new[] {1, 0, 2, 1});

        Console.WriteLine(res);*/

        /*var res = new SolutionPartitionLabels().PartitionLabels('ababcbacadefegdehijhklij');

        Console.WriteLine(res);*/


        /*var res = new Solution().MyPow(2.10000, 3);
        Console.WriteLine(res);*/


        /*var res = new Solution().IsValidSudoku(new[]
        {
            new[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
            new[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            new[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            new[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
        });*/

        /*var res = new SolutionIsValidSudoku().IsValidSudoku(new[]
      {
          new[] {'.','4','.','.','.','.','.','.','.'},
          new[] {'.','.','4','.','.','.','.','.','.'},
          new[] {'.','.','.','1','.','.','7','.','.'},
          new[] {'.','.','.','.','.','.','.','.','.'},
          new[] {'.','.','.','3','.','.','.','6','.'},
          new[] {'.','.','.','.','.','6','.','9','.'},
          new[] {'.','.','.','.','1','.','.','.','.'},
          new[] {'.','.','.','.','.','.','2','.','.'},
          new[] {'.','.','.','8','.','.','.','.','.'},

      });

         
        Console.WriteLine(res);*/
        
            /*public class Solution {
    public double MyPow(double x, int n)
    {

        if (n < -1)
        {
            return 1/(x * MyPow(x,n + 1));
        }
        if (Math.Abs(n) == 1) 
            return Math.Round(x,5,MidpointRounding.AwayFromZero);
        
        return x * MyPow(x,n - 1);
    }
}*/

/*class Solution2
{
    List<List<int>> output = new List<List<int>>();
    int n;
    int k;
    private int _target;

    public void backtrack(int first, LinkedList<int> curr)
    {
        // if the combination is done
        
        if (curr.Sum() == _target && curr.Count() == k)
        {
            Console.WriteLine(String.Join(',',curr));
            output.Add((curr.ToList()));
        }

        for (int i = first; i < n + 1; ++i)
        {
            // add i into the current combination
            curr.AddLast(i);
            // use next integers to complete the combination
            backtrack(i + 1, curr);
            // backtrack
            curr.RemoveLast();
        }
    }

    public int combine(int k, int n, int target)
    {
        _target = target;
        this.n = n;
        this.k = k;
        backtrack(1,new LinkedList<int>());
        return output.Count()!;
    }
}


class Solution
{
    List<List<int>> output = new List<List<int>>();
    int n;
    int k;

    public void backtrack(int first, LinkedList<int> curr)
    {
        // if the combination is done
        
        if (curr.Count() == k)
            output.Add((curr.ToList()));

        for (int i = first; i < n + 1; ++i)
        {
            // add i into the current combination
            curr.AddLast(i);
            // use next integers to complete the combination
            backtrack(i + 1, curr);
            // backtrack
            Console.WriteLine(string.Join(',',curr));
            curr.RemoveLast();
            Console.WriteLine(string.Join(',',curr));
        }
    }

    public List<List<int>> combine(int n, int k)
    {
        this.n = n;
        this.k = k;
        backtrack(1, new LinkedList<int>());
        return output;
    }
}*/

/*public class Solution
{
    public int CountCharacters(string[] words, string chars)
    {
        var dict = ToDictionary(chars);

        var res = 0;

        bool wordOk;
        foreach (var word in words)
        {
            var wordDict = ToDictionary(word);
            wordOk = true;

            foreach (var entry in wordDict)
            {
                if (!dict.ContainsKey(entry.Key))
                {
                    wordOk = false;
                    break;
                }

                if (dict[entry.Key] < entry.Value)
                {
                    wordOk = false;
                    break;
                }

                dict[entry.Key]--;
            }

            if (wordOk) res += word.Length;
            dict = ToDictionary(chars);
        }


        return res;
    }

    private static Dictionary<char, int> ToDictionary(string chars)
    {
        return chars.ToCharArray()
            .GroupBy(r => r).ToDictionary(r => r.Key, v => v.Count());
    }
}*/


/*public class MyQueue
{
    private Stack<int> _stack1;
    private Stack<int> _stack2;

    /** Initialize your data structure here. #1#
    public MyQueue()
    {
        _stack1 = new Stack<int>();
        _stack2 = new Stack<int>();
    }

    /** Push element x to the back of queue. #1#
    public void Push(int x)
    {
        _stack1.Push(x);
    }

    /** Removes the element from in front of queue and returns that element. #1#
    public int Pop()
    {
        if (_stack2.Count > 0) return _stack2.Pop();

        NewMethod();

        return _stack2.Pop();
    }

    private void NewMethod()
    {
        while (_stack1.Count > 0)
        {
            _stack2.Push(_stack1.Pop());
        }
    }

    /** Get the front element. #1#
    public int Peek()
    {
        if (_stack2.Count > 0) return _stack2.Peek();

        NewMethod();

        return _stack2.Peek();
    }

    /** Returns whether the queue is empty. #1#
    public bool Empty()
    {
        return _stack1.Count == 0 && _stack2.Count == 0;
    }
}*/

/*public class Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        if (rec1[0] <= rec2[0] && rec1[2] <= rec2[0]) return false;
        
        if (rec2[0] <= rec1[0] && rec2[2] <= rec1[0]) return false;
        
        if (rec1[1] <= rec2[1] && rec1[3] <= rec2[1]) return false;
        
        if (rec2[1] <= rec1[1] && rec2[3] <= rec1[1]) return false;

        return true;
        
    }
}*/
    }
}