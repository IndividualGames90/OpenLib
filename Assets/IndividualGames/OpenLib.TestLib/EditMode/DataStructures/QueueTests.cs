using IndividualGames.OpenLib.DataStructure.LinkedList;
using NUnit.Framework;

namespace IndividualGames.OpenLib.Tests.EditMode
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Initialization_Insertion()
        {
            Queue<int> queue = new();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(3);

            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void Enqueue_Dequeue_Peek()
        {
            Queue<int> queue = new();
            var elementCount = 5;

            for (int i = 0; i < elementCount; i++)
            {
                queue.Enqueue(i);
            }
            Assert.AreEqual(elementCount, queue.Count);
            Assert.AreEqual(0, queue.Peek());

            for (int i = 0; i < elementCount; i++)
            {
                Assert.AreEqual(i, queue.Dequeue());
            }
            Assert.AreEqual(0, queue.Count);
        }
    }
}