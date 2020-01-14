namespace ConsoleApp4
{
    public class SolutionReverseList
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null, current = head;
            while (current != null) { 
                var next = current.next; 
                current.next = prev; 
                prev = current; 
                current = next; 
            } 
            head = prev;
            return head;
        }
    }
}