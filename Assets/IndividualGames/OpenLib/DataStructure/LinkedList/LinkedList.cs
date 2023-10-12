namespace IndividualGames.OpenLib.DataStructure.LinkedList
{
    /// <summary>
    /// LinkedList with tail.
    /// </summary>
    public class LinkedList<T>
    {
        /// <summary> Reference value to first element. </summary>
        public T Head => head.Value;
        private Node<T> head;

        /// <summary> Reference value to last element. </summary>
        public T Tail => tail.Value;
        private Node<T> tail;

        /// <summary> Total current number of elements. </summary>
        public int Count { get; private set; }

        /// <summary> Add new element as last. </summary>
        public virtual void AddLast(T value)
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
        }

        /// <summary> Add new element as first. </summary>
        public virtual void AddFirst(T value)
        {
            var newNode = new Node<T> { Value = value };
            Count++;

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            newNode.Next = head;
            head = newNode;
        }

        /// <summary> Remove first element. </summary>
        public virtual void RemoveFirst()
        {
            if (head == null)
            {
                return;
            }

            head = head.Next;

            if (head == null)
            {
                tail = null;
            }
            Count--;
        }

        /// <summary> Remove last element. </summary>
        public virtual void RemoveLast()
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

        /// <summary> Remove first occurance of given value. </summary>
        public virtual void RemoveFirstOccurance(T value)
        {
            if (head == null)
            {
                return;
            }
            if (head.Value.Equals(value))
            {
                RemoveFirst();
                return;
            }

            var current = head;
            while (current.Next != null)
            {
                if (current.Next.Value.Equals(value))
                {
                    if (current.Next == tail)
                    {
                        tail = current;
                    }
                    current.Next = current.Next.Next;
                    Count--;
                    return;
                }
            }
        }

        /// <summary> Confirm if value is contained within the list. </summary>
        public virtual bool Contains(T value)
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
            while (current.Next != null)
            {
                if (current.Next.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary> Check if list is empty. </summary>
        public virtual bool IsEmpty()
        {
            return head == null || Count == 0;
        }

        /// <summary> Clear all data from the list. </summary>
        public virtual void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }
    }
}