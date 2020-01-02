namespace ConsoleApp4
{
    public class SolutionRemoveNthFromEnd
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }

            public override string ToString()
            {
                return $"{nameof(val)}: {val}, {nameof(next)}: {next}";
            }
        }
            
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var p1 = head;
            var p2 = head;
            var i = 0;
            while (i++ < n) p2 = p2.next;

            if (p2 == null) return p1.next;

            while (p2?.next != null)
            {
                p2 = p2.next;
                p1 = p1.next;
            }

            // if (p1 == head) return p1.next;

            if (p1.next == null) return null;
                
            p1.next = p1.next.next;
            return head;
        }
    }
}