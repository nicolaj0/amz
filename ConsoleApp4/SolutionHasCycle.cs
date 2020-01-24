namespace ConsoleApp4
{
    public class SolutionHasCycle
    {
        public bool HasCycle(ListNode head)
        {
            if (head?.next == null)
            {
                return false;
            }

            var slow = head;
            var fast = head.next;

            while (slow != fast)
            {
                if (fast?.next == null) {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }
    }
}