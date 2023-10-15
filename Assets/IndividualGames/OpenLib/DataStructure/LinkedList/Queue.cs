using System;

namespace IndividualGames.OpenLib.DataStructure.LinkedList
{
    /// <summary>
    /// Queue utilizing LinkedList.
    /// </summary>
    public class Queue<T>
    {
        /// <summary> Total current number of elements. </summary>
        public int Count
        {
            get
            {
                return linkedList.Count;
            }
        }

        private LinkedList<T> linkedList = new();

        public void Enqueue(T value)
        {
            linkedList.AddFirst(value);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var returnValue = linkedList.Tail;
            linkedList.RemoveLast();
            return returnValue;
        }

        /// <summary> Front of the queue. </summary>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return linkedList.Tail;
        }

        public bool IsEmpty()
        {
            return linkedList.IsEmpty();
        }

        public void Clear()
        {
            linkedList.Clear();
        }
    }
}