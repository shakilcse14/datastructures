namespace DataStructures.Core.LinkedList
{
    public class Node<T>
    {
        public Node<T> NextNode { get; set; }
        public Node<T> PreviousNode { get; set; }
        public T Data { get; set; }

        public Node() { }

        public Node(T data)
        {
            Data = data;
        }
    }
}