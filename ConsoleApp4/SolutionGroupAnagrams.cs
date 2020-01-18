using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp4
{
    public class SolutionGroupAnagrams
    {
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            var orderesString = String.Join("", inputString.OrderBy(r => r));
            foreach (byte b in GetHash(orderesString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            _strs = strs;
            
            IList<IList<string>> p = new List<IList<string>>();

            var res = strs.ToList().Select(s => new {String = s, Key = GetHashString(s)});

            var ggg = res.GroupBy(d => d.Key).Select(r => r.Select(f=>f.String).ToList()).ToList();
            foreach (var eee in ggg)
            {
                p.Add(eee);
            }

            return p;
        }


        IList<IList<string>> output = new List<IList<string>>();

        private string[] _strs;
    }
}