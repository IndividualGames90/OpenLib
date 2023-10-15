using System;

namespace IndividualGames.OpenLib.DataStructure.LinkedList
{
    /// <summary>
    /// Stack utilizing LinkedList.
    /// </summary>
    public class Stack<T>
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

        public void Push(T value)
        {
            linkedList.AddFirst(value);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var returnValue = linkedList.Head;
            linkedList.RemoveFirst();
            return returnValue;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return linkedList.Head;
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