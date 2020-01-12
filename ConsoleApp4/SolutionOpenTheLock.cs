using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    /* var res = new Solution().OpenLock(new[] {"0201", "0101", "0102", "1212", "2002"}, "0202");
            Console.WriteLine(res);*/
    
    public class SolutionOpenTheLock
    {
        public int distance(int a, int b)
        {
            var min = Math.Min(a, b);
            var max = Math.Max(a, b);
            return Math.Min(Math.Abs(max - min), Math.Abs(min - max + 10));
        }

        public int OpenLock(string[] deadends, string target)
        {
            int compute(int[] s, int[] h, int i)
            {
                var compute1 = s[i] + h[i];
                return compute1 > 9 ? 0 : compute1 < 0 ? 9 : compute1;
            }

            var lockState = new[] {0, 0, 0, 0};
            var targeState = TargeState(target);

            var deadEndStates = deadends.Select(TargeState).ToArray();

            var queue = new Queue<int[]>();
            var marked = new Dictionary<string, bool>();
            marked["0000"] = true;

            var disnatces = new int[]
            {
                distance(targeState[0], 0),
                distance(targeState[1], 0),
                distance(targeState[2], 0),
                distance(targeState[3], 0),
            };

            var distanceInit = 0;

            queue.Enqueue(lockState);

            var helpers = new[]
            {
                new[] {1, 0, 0, 0},
                new[] {-1, 0, 0, 0},
                new[] {0, 1, 0, 0},
                new[] {0, -1, 0, 0},
                new[] {0, 0, 1, 0},
                new[] {0, 0, -1, 0},
                new[] {0, 0, 0, 1},
                new[] {0, 0, 0, -1},
            };
            while (queue.Count > 0)
            {
                var s = queue.Dequeue();
                print(s);


                distanceInit += 1;

                foreach (var h in helpers)
                {
                    var ns = new[]
                    {
                        compute(s, h, 0),
                        compute(s, h, 1),
                        compute(s, h, 2),
                        compute(s, h, 3),
                    };

                    var newDistance = new int[]
                    {
                        distance(targeState[0], ns[0]),
                        distance(targeState[1], ns[1]),
                        distance(targeState[2], ns[2]),
                        distance(targeState[3], ns[3]),
                    };


                    var b = deadEndStates.Contains(ns);
                    var join = string.Join("", ns);
                    var visited = marked.ContainsKey(join) && marked[join];

                    if (!b && !visited /*&& IsCloser(newDistance, disnatces)*/)
                    {
                        if (string.Join("", ns) == target) return distanceInit;


                        queue.Enqueue(ns);
                        marked[join] = true;
                    }
                }
            }


            return -1;
        }

        private bool IsCloser(int[] newDistance, int[] disnatces)
        {
            return
                newDistance[0] <= disnatces[0] &&
                newDistance[1] <= disnatces[1] &&
                newDistance[2] <= disnatces[2] &&
                newDistance[3] <= disnatces[3];
        }

        private bool isTarget(int[] newDistance)
        {
            return
                newDistance[0] == 0 &&
                newDistance[1] == 0 &&
                newDistance[2] == 0 &&
                newDistance[3] == 0;
        }

        private static int[] TargeState(string target)
        {
            return target.ToCharArray().Select(c => Int32.Parse(c.ToString())).ToArray();
        }

        private void print(int[] ns)
        {
            Console.WriteLine(String.Join("", ns));
        }
    }
}