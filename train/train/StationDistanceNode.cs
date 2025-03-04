public class StationDistanceNode
{
    public int Distance;
    public StationDistanceNode? Next;

    public StationDistanceNode(int distance)
    {
        this.Distance = distance;
        this.Next = null;
    }
}
public class StationLinkedList
{
    private StationDistanceNode? head;

    // Add node at the end
    public void Insert(int distance)
    {
        StationDistanceNode newNode = new StationDistanceNode(distance);

        if (head == null)
        {
            head = newNode;
            return;
        }

        StationDistanceNode current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // Get distance at a specific index
    public int get_distance(int index)
    {
        StationDistanceNode? current = head;
        int count = 0;
        while (current != null)
        {
            if (count == index)
                return current.Distance;
            current = current.Next;
            count++;
        }
        return -1; // Return -1 if index is out of range
    }

    // Display all distances
    public void Display()
    {
        StationDistanceNode?
            current = head;
        while (current != null)
        {
            Console.Write(current.Distance + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}
