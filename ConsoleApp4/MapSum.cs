using System.Collections.Generic;

namespace ConsoleApp4
{
    public class MapSum
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public int Value { get; set; }

            public override string ToString()
            {
                return $"{nameof(Value)}: {Value}";
            }
        }

        public override string ToString()
        {
            return $"{nameof(Root)}: {Root}";
        }

        /** Initialize your data structure here. */
        public MapSum()
        {
            Root = new TrieNode();
        }

        public TrieNode Root { get; set; }
        public Dictionary<string,int> Map { get; set; } = new Dictionary<string, int>();

        public void Insert(string key, int val)
        {
            var delta = val - Map.GetValueOrDefault(key);

            Map[key] = delta;
            
            var cur = Root;
            cur.Value += delta;
            foreach (var c in key)
            {
                if (!cur.children.ContainsKey(c))
                {
                    cur.children[c] = new TrieNode();
                }
                
                cur = cur.children[c];
                cur.Value += delta;
            }

        }

        public int Sum(string prefix)
        {
            var cur = Root;
            foreach (var c in prefix)
            {
                cur = cur.children[c];
                if (cur == null)
                {
                    return 0;
                }
                
            }

            return cur.Value;

        }

        
    }
}