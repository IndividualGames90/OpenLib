#if UNITY_STANDALONE
using IndividualGames.OpenLib.DataStructure.LinkedList;
using System.Diagnostics;
using System.IO;

namespace IndividualGames.OpenLib.Experimentation.UI
{
    public class LinkedListBuildTest : OnClickThenExitApp
    {
        private void Awake()
        {
            testToRun = ComparisonWithLibrary;
        }

        private void ComparisonWithLibrary(int n)
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

            var fileName = "ComparisonWithLibrary.Tests.txt";
            File.AppendAllText(fileName, log1 + "\n");
            File.AppendAllText(fileName, log2 + "\n");
        }
    }
}
#endif