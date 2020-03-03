using System.Collections.Generic;

public class SolutionGetIntersectionNode {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var dict = new Dictionary<ListNode,bool>();
        var cur = headA;
        while (cur != null)
        {
            dict[cur] = true;
            cur = cur.next;
        }

        cur = headB;
        while (cur != null)
        {
            if (dict.ContainsKey(cur)) return cur;
            cur = cur.next;
        }
        
        return null;
    }

}