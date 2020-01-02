using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class MovingAverage
    {
        private readonly int _size;
        private Queue<int> _queue;

        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            _size = size;
            _queue = new Queue<int>();
        }

        public double Next(int val)
        {
            _queue.Enqueue(val);

            if (_queue.Count == _size + 1)
            {
                _queue.Dequeue();
            }

            return _queue.ToList().Average();
        }
    }
}