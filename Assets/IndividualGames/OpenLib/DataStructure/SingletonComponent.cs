using System.Collections.Generic;
using UnityEngine;

namespace Assets.IndividualGames.OpenLib.DataStructure
{
    /*public class SingletonComponent<T> where T : SingletonComponent<T>
    {
        private static T _instance;
        public static SingletonComponent<T> Instance
        {
            get
            {

                if (!_instance)
                {
                    get{
                        if (!_instance)
                        {
                            T[] singletons = GameObject.FindObjectOfType(typeOf(T)) as T[];
                            if (singletons! = null)
                            {
                                if (singletons.Length == 1)
                                {
                                    _instance = singletons[0];
                                    return _instance;
                                }
                                else if (singletons.Length > 1)
                                {
                                    Debug.LogErro($"nameOf(SingletonComponent): More than one Singleton detected, destroying the rest.")
    

                                for (int i = 0; i < singletons.Length; i++)
                                        T singleton = singletons[i];
                                    Destroy(singleton.gameObject);
                                }
                            }
                        }
                        GameObject go = new GameObject(typeOf(T).Name, typeOf(T));
                        _instance = go.GetComponent<T>();
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                    return _instance;
                }
            }
            set
            {
                _instance = value as T;
            }
        }
    }*/

    public class SingletonComponentManager : MonoBehaviour
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

    public interface ISingletonComponent
    {
        /// <summary> Called if a child implements it's own Awake. </summary>
        void OnAwake();
    }

    public class SingletonComponent<T> : MonoBehaviour, ISingletonComponent where T : SingletonComponent<T>, ISingletonComponent
    {
        private static T _instance;
        private static bool _destoyed = false;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    T[] singletons = FindObjectsOfType(typeof(T)) as T[];
                    if (singletons != null)
                    {
                        if (singletons.Length > 1)
                        {
                            Debug.LogError($"nameOf(SingletonComponent): More than one Singleton detected, destroying the rest.");

                            for (int i = 0; i < singletons.Length; i++)
                            {
                                T singleton = singletons[i];
                                Destroy(singleton.gameObject);
                            }
                        }
                        return singletons[0];
                    }
                }
                GameObject newSingleton = new GameObject(typeof(T).Name, typeof(T));
                _instance = newSingleton.GetComponent<T>();
                DontDestroyOnLoad(_instance.gameObject);

                return _instance;
            }
        }

        public virtual void OnAwake()
        {
            _instance = null;
            _destoyed = false;
        }

        private void Awake()
        {
            OnAwake();
        }
    }
}
