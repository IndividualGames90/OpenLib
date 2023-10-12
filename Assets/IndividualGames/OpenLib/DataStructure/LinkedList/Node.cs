namespace IndividualGames.OpenLib.DataStructure.LinkedList
{
    /// <summary>
    /// Node for training linked list.
    /// </summary>
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}