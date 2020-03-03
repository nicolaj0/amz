using System;
using System.Text;

class Resultmojitor
{
    /*
     * Complete the 'mojitor' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER startOfCount
     *  2. INTEGER endOfCount
     */

    public static string mojitor(int startOfCount, int endOfCount)
    {
       
        var sb = new StringBuilder();
        Console.WriteLine(startOfCount);
        Console.WriteLine(endOfCount);

        startOfCount = Math.Max(startOfCount, 1);
        endOfCount = Math.Min(endOfCount, 110);
        for (int i =startOfCount; i <= endOfCount; i++)
        {
            if (i > startOfCount)
            {
                if ((i - 1) % 11 == 0)
                {
                    sb.AppendLine();
                }
                else
                {
                    sb.Append(" ");
                }
            }

            if (i % 3 == 0)
            {
                sb.Append("Menthe");
            }

            if (i % 5 == 0)
            {
                sb.Append("Glace");
            }
            if (i % 7 == 0)
            {
                sb.Append("Rhum");
            }
            
            
            if (i % 3 == 0 && i % 5 == 0 && i % 7 == 0)
            {
                sb.Append("=Mojito");
            }

            if (i % 3 > 0 && i % 5 > 0 && i % 7 > 0)
            {
                sb.Append(i);
            }
        }

        return sb.ToString();
    }
}