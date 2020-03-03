using System;
using System.Text;

public class Solutionencode {
    public String encode(String s) {

        StringBuilder builder = new StringBuilder();
        char[] chars = s.ToCharArray();
        char current = chars[0];
        int count = 1;

        for (int i = 1; i < chars.Length; i++) {
            if (current == chars[i]){
                count++;
            } else {
                if (count > 1) builder.Append(count);
                builder.Append(current);
                current = chars[i];
                count = 1;
            }
        }
        if (count > 1) builder.Append(count);
        builder.Append(current);
        return builder.ToString();
    }
}