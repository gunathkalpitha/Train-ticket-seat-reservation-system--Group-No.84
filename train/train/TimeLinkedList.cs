public class TimeLinkedList
{
    private class Node
    {
        public string Data;
        public Node? Next;
        public Node(string data) { Data = data; Next = null; }
    }

    private Node? head;

    // Insert new time
    public void Insert(string time)
    {
        Node newNode = new Node(time);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }
    }

    // Get time by index
    public string GetTime(int index)
    {
        Node? temp = head;
        int count = 0;
        while (temp != null)
        {
            if (count == index)
            {
                return temp.Data;
            }
            temp = temp.Next;
            count++;
        }
        return "Invalid";
    }
}
