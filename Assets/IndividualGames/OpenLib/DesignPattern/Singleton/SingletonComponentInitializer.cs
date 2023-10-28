using UnityEngine;

namespace IndividualGames.OpenLib.DesignPattern
{
    /// <summary>
    /// Manager for SingletonBehaviors. Callback to their Awakes.
    /// Persistant.
    /// Req: OnScene and high in Awake order.
    /// </summary>
    public class SingletonComponentInitializer : MonoBehaviour
    {
        private SingletonBehavior[] singletons;

        private static SingletonComponentInitializer _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                DontDestroyOnLoad(gameObject);
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }


            singletons = FindObjectsOfType(typeof(SingletonBehavior)) as SingletonBehavior[];

            foreach (var singleton in singletons)
            {
                singleton.OnAwake();
            }
        }
    }
}
