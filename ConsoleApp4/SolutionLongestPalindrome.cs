namespace ConsoleApp4
{
    public class SolutionLongestPalindrome
    {
        public string LongestPalindrome(string s)
        {
            var res = Sybstr(s);
            var i = 0;
            while ( i < s.Length)
            {
                var sybstr = Sybstr(s.Substring(0, s.Length - i++));
                var sybstr1 = Sybstr(s.Substring(i, s.Length - i));
                if (sybstr.Length > res.Length) res = sybstr;
                if (sybstr1.Length > res.Length) res = sybstr1;
            }


            return res;
        }


        private string Sybstr(string s)
        {
            var sybstr = CheckPalindrome(s);
            if (sybstr == null) return s;
            while (sybstr.Length < s.Length)
            {
                var newSubs = CheckPalindrome(sybstr);
                if (newSubs == null)
                {
                    break;
                }

                sybstr = newSubs;
            }


            return sybstr;
        }

        private string CheckPalindrome(string substring)
        {
            if (substring.Length == 0) return null;
            if (substring.Length == 1) return null;
            var checkPalindrome = substring.Substring(1, substring.Length - 2);
            if (substring[0] != substring[substring.Length - 1])
            {
                return checkPalindrome;
            }

            return CheckPalindrome(checkPalindrome);
        }
    }
}