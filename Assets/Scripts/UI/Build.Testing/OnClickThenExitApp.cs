#if UNITY_STANDALONE
using System;
using UnityEngine;

namespace IndividualGames.OpenLib.Experimentation.UI
{

    /// <summary>
    /// Runs a test on button click, then exits app.
    /// </summary>
    public abstract class OnClickThenExitApp : MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private int iterations = 1;

        /// <summary> Assign this with a test method to run. </summary>
        protected Action<int> testToRun;

        public void OnClickThenExit()
        {
            for (int i = 0; i < iterations; i++)
            {
                testToRun?.Invoke(1000);
                testToRun?.Invoke(10000);
                testToRun?.Invoke(100000);
            }

            Application.Quit();
        }
    }
}
#endif