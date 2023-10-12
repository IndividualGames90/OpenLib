namespace IndividualGames.OpenLib.DataStructure.LinkedList
{
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