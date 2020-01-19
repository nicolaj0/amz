using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class MinStack
    {
        Stack<int> stack = new Stack<int>();
        Stack<int> minStack = new Stack<int>();

        int min = Int32.MaxValue;

        public MinStack()
        {
        }

        public void Push(int x)
        {
            if (x <= min)
            {
                minStack.Push(x);
                min = x;
            }

            stack.Push(x);
        }

        public void Pop()
        {
            var pop = stack.Pop();
            if (pop == min)
            {
                if (minStack.Count > 1)
                {
                    minStack.Pop();
                    min = minStack.Peek();
                }
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return min;
        }
    }
}