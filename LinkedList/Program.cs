 internal class Program
{
    static void Main(string[] args)
    {

        List<int> numbers = [4, 5, 1, 9];
        LinkedList linkedList = new LinkedList();

        linkedList.InsertLast(4);
        linkedList.InsertLast(5);
        linkedList.InsertLast(1);
        linkedList.InsertLast(9);
        Console.WriteLine("List after appending: ");
        linkedList.Print();

        linkedList.InsertFront(12);
        Console.WriteLine("List after inserting in the beginning: ");
        linkedList.Print();
        
        Node secondNode = linkedList.head.next;
        linkedList.InsertAfter(3, 15);
        Console.WriteLine("List after inserting in the beginning: ");
        linkedList.Print();

        linkedList.DeleteNode(12);
        Console.WriteLine("List after appending in the beginning of the list: ");
        linkedList.Print();
    }

    
    //Definition for singly-linked list.
    /*
     * the link will contain the address of next node and is 
     initialized to null.
    */
    public class Node
    {
        public int val;
        public Node next;
        public Node(int x)
        {
            val = x;
            next = null;
        }
    }

    /*
     * now our node has been created. so, we will create a linked list class now.
     * When instatiated, it just has the head, which is NULL.
    */
    public class LinkedList
    {
        public Node head;

        /* method that insert in the beggining 
 * the first node, head, will be null when the linked list is instantiated.
 * when we want to add any node at the front, we want the head to point to it.
 * the previous head node is now the second node of linked list because the new node is added at the front.
 * so, we will assign head to the new node.
*/
        public void InsertFront(int val)
        {
            Node new_node = new Node(val);
            new_node.next = head;
            head = new_node;
        }

        /* method to insert a node in a specific position
    */
        public void InsertAfter(int position, int val)
        {
            if (position < 0)
            {
                Console.WriteLine($"the previous node can't be less then 0");
                return;
            }
            Node new_node = new Node(val);

            if (position == 0)
            {
                new_node.next = head;
                head = new_node;
                return;
            }

            Node current = head;
            Node previous = null;

            int currentIndex = 0;

            while (current != null && currentIndex < position)
            {
                previous = current;
                current = current.next;
                currentIndex++;
            }
            if(previous != null)
            {
                previous.next = new_node;
            }
            new_node.next = current;
        }

        /* method to insert a node in the end of the list
         * if the linked list is empty, then we simply add the new node as the Head of the linked list.
         * if the linked list ain't empty, then we find the last node and make next of the last node to the new
         * node, hence the new node is the last node now;
        */
        public void InsertLast(int val)
        {
            Node new_node = new Node(val);
            if (head == null)
            {
                head = new_node;
                return;
            }
            Node last_node = GetLastNode();
            last_node.next = new_node;
        }

        /* method to get the last node
         * the last node will be the one with its next pointing to null. Hence we will across the list until we find the 
         * node with next as null and return that node as last node.
        */
        public Node GetLastNode()
        {
            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        //the method deletes a node based on its value
        public void DeleteNode(int key)
        {
            Node temp = head;
            Node prev = null;

            //if the deleted node is the head node
            if (temp != null && temp.val == key)
            {
                head = temp.next; //change the head
                return;
            }

            //search for the node that will be deleted, maintaining the previous node as reference.
            while (temp != null && temp.val != key)
            {
                prev = temp;
                temp = temp.next;
            }

            //if it doesnt have in the list
            if (temp == null)
            {
                return;
            }

            //
            prev.next = temp.next;
        }
        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}