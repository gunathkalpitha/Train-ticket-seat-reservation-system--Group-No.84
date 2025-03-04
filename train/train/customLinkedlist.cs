public class CustomLinkedList
{
    private DistanceNode? head;

    // Insert a new station at the end
    public void Insert(int data)
    {
        DistanceNode newNode = new DistanceNode(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        DistanceNode current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // Check if a station exists in the linked list
    public bool Contains(int data)
    {
        DistanceNode? current = head;
        while (current != null)
        {
            if (current.Data == data)
                return true;
            current = current.Next;
        }
        return false;
    }

    // Check if two stations are in the same train route
    public bool IsValidRoute(int start, int end)
    {
        return Contains(start) && Contains(end);
    }

    // Display all stations in the linked list
    public void Display()
    {
        DistanceNode? current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}
