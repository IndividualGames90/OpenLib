using IndividualGames.OpenLib.DataStructure.LinkedList;
using NUnit.Framework;

namespace IndividualGames.OpenLib.Tests.EditMode
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Initialization_Insertion()
        {
            Stack<int> stack = new();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(3);

            Assert.AreEqual(4, stack.Count);
            Assert.AreEqual(3, stack.Peek());
        }

        [Test]
        public void Push_Pop_Peek()
        {
            Stack<int> stack = new();
            var elementCount = 5;

            for (int i = 0; i < elementCount; i++)
            {
                stack.Push(i);
            }
            Assert.AreEqual(elementCount, stack.Count);
            Assert.AreEqual(4, stack.Peek());

            var loweringIndex = elementCount;
            for (int i = 0; i < elementCount; i++)
            {
                Assert.AreEqual(--loweringIndex, stack.Pop());
            }
            Assert.AreEqual(0, stack.Count);
        }
    }
}