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

    /// <summary>
    /// Linked List implementation for training purposes.
    /// </summary>
    public class LinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public void AddLast(T value)
        {
            var newNode = new Node<T> { Value = value };
            Count++;

            if (head == null)
            {
                head = newNode;
                tail = head;
                return;
            }

            tail.Next = newNode;
            tail = newNode;

            #region TAILLESS OPERATION
            ///This segment is for without tail, kept for learning purposes.
            /*var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            tail = current.Next;*/
            #endregion
        }

        public void AddFirst(T value)
        {
            var newNode = new Node<T> { Value = value };
            Count++;

            newNode.Next = head;
            head = newNode;

            if (head.Next == null)
            {
                tail = newNode;
            }
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                return;
            }
            if (head.Next == null)
            {
                head = null;
                tail = null;
                Count--;
                return;
            }

            var current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
            tail = current;
            Count--;
        }

        public void Remove(T value)
        {
            if (head == null)
            {
                return;
            }
            if (head.Value.Equals(value))
            {
                head = head.Next;
                Count--;
                return;
            }

            var current = head;
            while (current.Next != null)
            {
                if (current.Next.Value.Equals(value))
                {
                    current.Next = current.Next.Next;
                    tail = current.Next;
                    Count--;
                    return;
                }
            }
        }

        public bool Contains(T value)
        {
            if (head == null)
            {
                return false;
            }
            if (head.Value.Equals(value))
            {
                return true;
            }

            var current = head;
            while (current.Next is != null previous )
            {
                if (current.Next.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
    }
}