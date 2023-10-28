using UnityEngine;

namespace IndividualGames.OpenLib.DesignPattern
{
    /// <summary>
    /// Singleton and a component.
    /// Use must call in awake if derived for an on scene GameObject.
    /// </summary>
    public class SingletonComponent<T> : SingletonBehavior, ISingletonComponent where T : SingletonComponent<T>, ISingletonComponent
    {
        private static T _instance;
        private static bool _destroyed = false;

        public delegate void AwakeSubsitute();
        private AwakeSubsitute _awake;

        public static T Instance
        {
            get
            {
                if (_destroyed)
                {
                    return null;
                }

                if (_instance == null)
                {
                    T[] singletons = FindObjectsOfType(typeof(T)) as T[];
                    if (singletons != null)
                    {
                        if (singletons.Length > 1)
                        {
                            Debug.LogError($"{nameof(SingletonComponent<T>)}: More than one Singleton detected, destroying the rest.");

                            for (int i = 1; i < singletons.Length; i++)
                            {
                                T singleton = singletons[i];
                                DestroyImmediate(singleton.gameObject);
                                singleton = null;
                            }
                        }
                        return singletons[0];
                    }

                    GameObject newSingleton = new GameObject(typeof(T).Name, typeof(T));
                    _instance = newSingleton.GetComponent<T>();
                    //DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }

        /// <summary> Children must call this method in their Awake and 
        /// pass a substitute to serve as their Awake. </summary>
        public void MustCallInAwake(AwakeSubsitute awake)
        {
            _awake = awake;
            OnAwake();
        }

        /// <summary> Actual Awake. </summary>
        public override void OnAwake()
        {
            _destroyed = false;
            _ = Instance;

            if (_awake != null)
            {
                _awake();
            }
        }

        /// <summary> Awake of this, don't run for children. </summary>
        private void Awake()
        {
            OnAwake();
        }

        private void OnDestroy()
        {
            _destroyed = true;
        }
    }
}
