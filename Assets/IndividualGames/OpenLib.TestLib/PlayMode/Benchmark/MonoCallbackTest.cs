using System.Collections;
using UnityEngine;

namespace IndividualGames.OpenLib.TestLib.PlayMode.Benchmark
{
    /// <summary>
    /// Add to scene and crank up the amount. Then play and profile.
    /// </summary>
    public class MonoCallbackTest : MonoBehaviour
    {
        [SerializeField] private int _amountOfMonos;
        [SerializeField] private GameObject _withCallbacks;
        [SerializeField] private GameObject _withoutCallbacks;

        private void Awake()
        {
            StartCoroutine(StartTest());
        }

        private IEnumerator StartTest()
        {
            yield return new WaitForSeconds(3);
            Debug.Log("With Callbacks Started");
            for (int i = 0; i < _amountOfMonos; i++)
            {
                Instantiate(_withCallbacks);
            }
            yield return new WaitForSeconds(3);
            Debug.Log("Without Callbacks Started");
            for (int i = 0; i < _amountOfMonos; i++)
            {
                Instantiate(_withoutCallbacks);
            }
        }
    }
}