using IndividualGames.OpenLib.DataStructure.LinkedList;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace IndividualGames.OpenLib.Tests.Editor
{
    public class LinkedListTests
    {
        [Test]
        public void InitializationAndInsertion()
        {
            LinkedList<int> linkedList = new();

            for (int i = 0; i < 5; i++)
            {
                linkedList.AddLast(i);
            }

            Assert.AreEqual(5, linkedList.Count);
        }

        [Test]
        public void FirstAndLastModification()
        {
            LinkedList<int> linkedlist = new();

            linkedlist.AddFirst(1);///[1]
            Assert.AreEqual(1, linkedlist.Count);
            Assert.IsTrue(linkedlist.Contains(1));

            linkedlist.RemoveFirst();///[]
            Assert.True(linkedlist.IsEmpty());
            Assert.True(linkedlist.Count == 0);

            linkedlist.AddFirst(2);
            linkedlist.AddLast(3);///[2,3]
            Assert.IsFalse(linkedlist.Contains(1));
            Assert.AreNotEqual(3, linkedlist.Count);

            linkedlist.RemoveLast();///[2]
            Assert.AreEqual(1, linkedlist.Count);
        }

        [Test]
        public void ClearTheList()
        {
            LinkedList<int> linkedlist = new();

            linkedlist.AddFirst(1);
            linkedlist.AddFirst(2);
            linkedlist.Clear();
            Assert.AreEqual(0, linkedlist.Count);
            linkedlist.AddFirst(1);
            linkedlist.AddFirst(2);
            Assert.AreEqual(2, linkedlist.Head);
        }

        [Test]
        public void RemoveFromEmpty()
        {
            LinkedList<int> linkedList = new();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.Clear();

            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.RemoveFirstOccurance(1);
        }

        [Test]
        public void RemoveFromMiddle()
        {
            LinkedList<int> linkedlist = new();

            linkedlist.AddLast(1);
            linkedlist.AddLast(2);
            linkedlist.AddLast(3);///list = [1,2,3]
            linkedlist.RemoveFirstOccurance(2);///list = [1,3]
            Assert.AreEqual(3, linkedlist.Tail);
        }

        [Test]
        public void BoundaryTesting_LotsOfInsertions()
        {
            LinkedList<int> linkedlist = new();

            for (int i = 1; i <= 1000; i++)
            {
                linkedlist.AddLast(i);
            }
            Assert.AreEqual(1000, linkedlist.Tail);
            Assert.AreEqual(1000, linkedlist.Count);
        }

        [Test]
        public void ParallelModification()
        {
            ThreadSafeLinkedList<int> linkedlist = new();

            for (int i = 0; i < 10; i++)
            {
                linkedlist.AddLast(i);
            }

            Action insertLots = () =>
            {
                for (int i = 0; i < 20; i++)
                {
                    linkedlist.AddLast(i);
                }
            };

            Action removeLots = () =>
            {
                for (int i = 0; i < 20; i++)
                {
                    linkedlist.RemoveFirst();
                }
            };

            Parallel.Invoke(insertLots, removeLots);

            Assert.AreEqual(10, linkedlist.Count);
        }
    }
}