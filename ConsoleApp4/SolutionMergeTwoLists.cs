namespace ConsoleApp4
{
    public class SolutionMergeTwoLists
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
        
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            var p1 = l1.val > l2.val ? l2 : l1;
            var p2 = l1.val > l2.val ? l1 : l2;

            var res = new ListNode(p1.val);
            p1 = p1.next;
            var current = res;

            while (true)
            {
                if (p1 == null)
                {
                    current.next = p2;
                    break;
                }

                if (p2 == null)
                {
                    current.next = p1;
                    break;
                }
                if (p1.val <= p2.val )
                {
                    current.next = new ListNode(p1.val);
                    p1 = p1.next;
                }
                else 
                {
                    current.next = new ListNode(p2.val);
                    p2 = p2.next;
                }


                current = current.next;
            }

            return res;
        }
    }
}