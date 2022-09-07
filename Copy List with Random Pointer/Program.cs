using System;

namespace Copy_List_with_Random_Pointer
{
    class Program
    {
        static void Main(string[] args)
        {
            Node start = new Node(1);
            start.next = new Node(2);
            start.next.next = new Node(3);
            start.next.next.next = new Node(4);
            start.next.next.next.next = new Node(5);

            // 1's random points to 3  
            start.random = start.next.next;

            // 2's random points to 1  
            start.next.random = start;

            // 3's and 4's random points to 5  
            start.next.next.random = start.next.next.next.next;
            start.next.next.next.random = start.next.next.next.next;

            // 5's random points to 2  
            start.next.next.next.next.random = start.next;

            Console.WriteLine("Original list : ");

            Solution sol = new Solution();

            sol.Print(start);

            Console.WriteLine("Cloned list : ");
            Node cloned_list = sol.CopyRandomList(start);
            sol.Print(cloned_list);
        }
    }


    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }


    public class Solution
    {
        public void Print(Node head)
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.val);
                temp = temp.next;
            }
        }
        public Node CopyRandomList(Node head)
        {
            // Step 1 - copy the values
            // Step 2 - copy the random pointers
            // Step 3 - copy the next pointers
            // structure - orgNode->copyNode->orgNode->copyNode->............

            // Step 1
            var temp = head;
            while (temp != null)
            {
                var next = temp.next;
                // keeping the first node of temp as original and next we are creating a new node which is copy node
                temp.next = new Node(temp.val);
                temp.next.next = next;
                temp = next;
            }
            // Step 2
            temp = head;
            while (temp != null)
            {
                // copy the random pointer of original and linked with copied node random
                temp.next.random = temp.random?.next;
                // take next to next original node
                temp = temp.next?.next;
            }
            Console.WriteLine(2);
            // Step 3
            temp = head;
            var copy = temp?.next;
            var output = copy;
            while (temp != null && copy != null)
            {
                temp.next = copy.next;
                copy.next = temp.next?.next;
                temp = temp.next;
                copy = copy.next;
            }

            return output;
        }
    }
}
