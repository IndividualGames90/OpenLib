using UnityEngine;

namespace IndividualGames.OpenLib.DesignPattern
{
    /// <summary>
    /// Base class for SingletonComponent.
    /// </summary>
    public abstract class SingletonBehavior : MonoBehaviour
    {
        public abstract void OnAwake();
    }
}
