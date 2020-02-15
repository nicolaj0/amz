using System;

public class SolutionReorderLogFiles
{
    public string[] ReorderLogFiles(string[] logs)
    {
        Array.Sort(logs, (log1, log2) =>
        {
            var split1 = log1.Split(" ", 2);
            var split2 = log2.Split(" ", 2);
            var isDigit1 = char.IsDigit(split1[1][0]);
            var isDigit2 = char.IsDigit(split2[1][0]);
            if (!isDigit1 && !isDigit2) {
                var cmp = String.Compare(split1[1], split2[1], StringComparison.Ordinal);
                if (cmp != 0) return cmp;
                return String.Compare(split1[0], split2[0], StringComparison.Ordinal);
            }
            return isDigit1 ? isDigit2 ? 0 : 1 : -1;
        });
        return logs;
        /*return logs
            .Select(r => r.Split(" "))
            .Select(w => new {key = w.First(), items = w, IsLetter = w.Skip(1).First().All(char.IsLetter)})
            .ToList()
            .OrderByDescending(w => w.IsLetter)
            .ThenBy(w => w.IsLetter ? w.items[1] : 0)
            .ThenBy(w => w.items[0])
            .Select(w => string.Join(" ", w.items))
            .ToArray();*/

    }
}