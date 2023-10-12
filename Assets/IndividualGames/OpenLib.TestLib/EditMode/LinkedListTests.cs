using IndividualGames.OpenLib.DataStructure.LinkedList;
using NUnit.Framework;

namespace IndividualGames.OpenLib.Tests.Editor
{
    public class LinkedListTests
    {
        [Test]
        public void LinkedListIsInitialized()
        {
            LinkedList<int> linkedList = new();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);
            linkedList.AddFirst(5);

        }
    }
}