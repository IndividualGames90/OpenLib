namespace IndividualGames.OpenLib.DataStructure.LinkedList
{
    /// <summary>
    /// LinkedList with tail.
    /// </summary>
    public class LinkedList<T>
    {
        public T Head => head.Value;
        private Node<T> head;

        public T Tail => tail.Value;
        private Node<T> tail;

        public int Count { get; private set; }

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

        public virtual bool IsEmpty()
        {
            return head == null || Count == 0;
        }

        public virtual void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }
    }

    /// <summary>
    /// Thread safe LinkedList for parallel processing.
    /// </summary>
    public class ThreadSafeLinkedList<T> : LinkedList<T>
    {
        private readonly object _lock = new object();

        public override void AddLast(T value)
        {
            lock (_lock)
            {
                base.AddLast(value);
            }
        }

        public override void AddFirst(T value)
        {
            lock (_lock)
            {
                base.AddFirst(value);
            }
        }

        public override void RemoveFirst()
        {
            lock (_lock)
            {
                base.RemoveFirst();
            }
        }

        public override void RemoveLast()
        {
            lock (_lock)
            {
                base.RemoveLast();
            }
        }

        public override void RemoveFirstOccurance(T value)
        {
            lock (_lock)
            {
                base.RemoveFirstOccurance(value);
            }
        }

        public override bool Contains(T value)
        {
            lock (_lock)
            {
                return base.Contains(value);
            }
        }

        public override bool IsEmpty()
        {
            lock (_lock)
            {
                return base.IsEmpty();
            }
        }

        public override void Clear()
        {
            lock (_lock)
            {
                base.Clear();
            }
        }
    }
}