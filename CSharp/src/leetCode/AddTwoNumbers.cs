namespace CSharp.leetCode; 

public static class AddTwoNumbers {
    /// <summary>
    /// https://leetcode.com/problems/add-two-numbers/
    /// You are given two non-empty linked lists representing two non-negative integers.
    /// The digits are stored in reverse order, and each of their nodes contains a single digit. Add
    /// the two numbers and return the sum as a linked list.
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// </summary>
    public static ListNode Solve(ListNode? l1, ListNode? l2) {
        ListNode? resultStart = null;
        ListNode? resultNode = null;

        int carry = 0;
        while (l1 != null || l2 != null || carry == 1) {
            int addResult = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = 0;
            if (addResult > 9) {
                addResult -= 10;
                carry = 1;
            }

            if (resultStart == null) resultNode = resultStart = new(addResult);
            else resultNode = resultNode!.next = new(addResult);
            
            l1 = l1?.next;
            l2 = l2?.next;
        }

        return resultStart!;
    }
        
    public class ListNode {
        public int val;
        public ListNode? next;
        
        public ListNode(int val = 0, ListNode? next=null) {
            this.val = val;
            this.next = next;
        }
    }
}