using IndividualGames.OpenLib.DataStructure.LinkedList;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SystemList = System.Collections.Generic.List<int>;

namespace IndividualGames.OpenLib.Tests.EditMode
{
    [TestFixture]
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

        [Test]
        public void InstantiateWithCollection()
        {
            SystemList list = new() { 1, 2, 3, 4, 5 };
            LinkedList<int> linkedList = new(list);

            Assert.AreEqual(5, linkedList.Count);
            Assert.AreEqual(1, linkedList.Head);
            Assert.AreEqual(5, linkedList.Tail);
            linkedList.RemoveLast();
            Assert.AreEqual(4, linkedList.Tail);
        }

        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void ComparisonWithLibrary(int n)
        {
            var linkedlist = new LinkedList<int>();
            var libraryLinkedList = new System.Collections.Generic.LinkedList<int>();

            var timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < n; i++)
            {
                linkedlist.AddLast(n);
            }
            timer.Stop();
            var myTime = timer.Elapsed.TotalMilliseconds;

            timer.Restart();
            for (int i = 0; i < n; i++)
            {
                libraryLinkedList.AddLast(n);
            }
            timer.Stop();
            var libraryTime = timer.Elapsed.TotalMilliseconds;

            var log1 = $"ComparisonWithLibrary: OpenLib.LinkedList took {myTime}ms for {n} AddLast";
            var log2 = $"ComparisonWithLibrary: System.LinkedList took {libraryTime}ms for {n} AddLast";

#if UNITY_EDITOR
            UnityEngine.Debug.Log(log1);
            UnityEngine.Debug.Log(log2);
#endif
#if UNITY_STANDALONE
            var fileName = "ComparisonWithLibrary.Tests.txt";
            File.AppendAllText(fileName, log1 + "\n");
            File.AppendAllText(fileName, log2 + "\n");
#endif
        }
    }
}