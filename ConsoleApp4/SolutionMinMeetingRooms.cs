using System;
using System.Linq;

public class SolutionMinMeetingRooms
{
    public int MinMeetingRooms(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;
        Array.Sort(intervals, (ints, ints1) => ints[0].CompareTo(ints1[0]));

        int nbOflapping = 0;
        for (int i = 0; i < intervals.Length; i++)
        {
            var cur = intervals[i];

            var previousMeetingsWithOverlap = intervals.Take(i ).Count(interval =>
                interval[0] < cur[0] && interval[1] > cur[0] ||
                interval[0] < cur[1] && interval[1] > cur[1] ||
                interval[0] >= cur[0] && interval[1] <= cur[1]);

            if (previousMeetingsWithOverlap > nbOflapping)
            {
                nbOflapping = previousMeetingsWithOverlap;
            }
        }

        return nbOflapping + 1;
    }
}