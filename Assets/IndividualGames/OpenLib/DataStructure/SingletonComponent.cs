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

    /// <summary>
    /// Manager for SingletonBehaviors. Callback to their Awakes.
    /// </summary>
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

        public delegate void AwakeSubsitute();
        private AwakeSubsitute _awake;

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
                            Debug.LogError($"{nameof(SingletonComponent<T>)}: More than one Singleton detected, destroying the rest.");

                            for (int i = 0; i < singletons.Length; i++)
                            {
                                T singleton = singletons[i];
                                Destroy(singleton.gameObject);
                            }
                        }
                        return singletons[0];
                    }

                    GameObject newSingleton = new GameObject(typeof(T).Name, typeof(T));
                    _instance = newSingleton.GetComponent<T>();
                    DontDestroyOnLoad(_instance.gameObject);
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
        public virtual void OnAwake()
        {
            _instance = null;
            _destoyed = false;

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
    }

    public class SingletonComponentTest : SingletonComponent<SingletonComponentTest>
    {
        public enum TestStageEnum
        {
            UnityAwake,
            SubstituteAwake
        }

        public TestStageEnum TestStage;


        private void Awake()
        {
            TestStage = TestStageEnum.UnityAwake;
            MustCallInAwake(AwakeTest);
        }

        private void AwakeTest()
        {
            TestStage = TestStageEnum.SubstituteAwake;
        }
    }
}
