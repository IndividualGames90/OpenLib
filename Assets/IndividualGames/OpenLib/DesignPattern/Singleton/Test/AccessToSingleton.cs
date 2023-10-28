using UnityEngine;

namespace IndividualGames.OpenLib.DesignPattern
{
    public class AccessToSingleton : MonoBehaviour
    {
        private void Awake()
        {
            SingletonComponentTest.Instance.TestValue = "AccessToSingleton changed.";
            SingletonComponentTest.TestValueStatic = "AccessToSingleton changed.";
            StartCoroutine(SingletonComponentTest.Instance.TestAfterDelay());
        }
    }
}