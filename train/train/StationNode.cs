public class DistanceNode
{
    public int Data;  // Station number
    public DistanceNode? Next; // Reference to the next node

    public DistanceNode(int data)
    {
        this.Data = data;
        this.Next = null;
    }
}
