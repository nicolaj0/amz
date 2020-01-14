using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    /* var res = new Solution().OpenLock(new[] {"0201", "0101", "0102", "1212", "2002"}, "0202");
            Console.WriteLine(res);*/
    
    class SolutionOpentheLock
    {
        public int OpenLock(String[] deadends, String target)
        {
            var dead = new HashSet<string>();
            foreach (var d in deadends) dead.Add(d);

            var queue = new Queue<string>();
            queue.Enqueue("0000");
            //  queue.Enqueue(null);

            var seen = new HashSet<string> {"0000"};

            var depth = 0;
            while (queue.Count > 0)
            {

                Console.WriteLine(queue.Count);
                var node = queue.Dequeue();
                if (node == null)
                {
                    depth++;
                    if (queue.Peek() != null)
                        queue.Enqueue(null);
                }
                else if (node.Equals(target))
                {
                    return depth;
                }
                else if (!dead.Contains(node))
                {
                    for (var i = 0; i < 4; ++i)
                    {
                        for (var d = -1; d <= 1; d += 2)
                        {
                            var y = ((node[i] - '0') + d + 10) % 10;
                            var nei = node.Substring(0, i) + ("" + y) + node.Substring(i + 1);
                            if (!seen.Contains(nei))
                            {
                                seen.Add(nei);
                                queue.Enqueue(nei);
                            }
                        }
                    }
                }
            }

            return -1;
        }
    }
}