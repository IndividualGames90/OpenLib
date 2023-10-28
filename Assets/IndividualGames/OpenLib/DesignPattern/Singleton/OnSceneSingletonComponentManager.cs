using System.Collections.Generic;
using UnityEngine;

namespace IndividualGames.OpenLib.DesignPattern
{
    /// <summary>
    /// Manager for SingletonBehaviors. Callback to their Awakes.
    /// </summary>
    public class OnSceneSingletonComponentManager : MonoBehaviour
    {
        private List<ISingletonComponent> singletons = new();

        private void Awake()
        {
            foreach (var singleton in singletons)
            {
                singleton.OnAwake();
            }
        }
    }
}
