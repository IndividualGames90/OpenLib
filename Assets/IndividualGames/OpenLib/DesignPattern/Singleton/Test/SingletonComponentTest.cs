using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndividualGames.OpenLib.DesignPattern
{
    /// <summary>
    /// Integration test for SingletonComponent
    /// </summary>
    public class SingletonComponentTest : SingletonComponent<SingletonComponentTest>
    {
        [Header("Scene Data:")]
        [SerializeField] private bool _sceneLoadTestActive = false;
        [SerializeField] private SceneAsset _thisScene;
        private static int SceneNumber = 0;

        [Header("Test Objects Data:")]
        [SerializeField] private GameObject _emptyTestObject;
        [SerializeField] private GameObject _emptyTestObjectOnScene;

        [HideInInspector]
        public string TestValue = "Initialization Value";
        public static string TestValueStatic = "Initialization Value";

        private static string _divider = "================================";

        public enum TestStageEnum
        {
            UnityAwake,
            SubstituteAwake
        }

        private void Awake()
        {
            Debug.Log($"=NEW LEVEL{_divider}");
            Debug.Log($"Scene {SceneNumber} has loaded.");


            Debug.Log($"Method entered: {TestStageEnum.UnityAwake}");
            PostValues(System.Reflection.MethodBase.GetCurrentMethod().Name);

            MustCallInAwake(AwakeSubstituteTest);

            if (_sceneLoadTestActive)
            {
                StartCoroutine(TestAfterDelay());
            }
        }

        private void AwakeSubstituteTest()
        {
            Debug.Log($"Method entered: {TestStageEnum.SubstituteAwake}");
            PostValues(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public IEnumerator TestAfterDelay()
        {
            Debug.Log($"Scene {SceneNumber + 1} WILL RELOAD in 2s...");
            yield return new WaitForSeconds(2);
            Debug.Log($"=NEW LEVEL{_divider}");
            SceneNumber++;
            Debug.Log($"Scene {SceneNumber} is loading...");
            SceneManager.LoadScene(_thisScene.name, LoadSceneMode.Single);
        }

        public void PostValues(string currentMethodName)
        {
            Debug.Log($"=RESULT{_divider}");
            Debug.Log($"={currentMethodName}=");
            Debug.Log($"{nameof(TestValue)}: {TestValue}");
            Debug.Log($"{nameof(TestValueStatic)}: {TestValueStatic}");

            if (_emptyTestObject == null)
            {
                Debug.Log($"{nameof(_emptyTestObject)} is null.");
            }
            else
            {
                Debug.Log($"{nameof(_emptyTestObject)} is NOT null.");
            }

            if (_emptyTestObjectOnScene == null)
            {
                Debug.Log($"{nameof(_emptyTestObjectOnScene)} is null.");
            }
            else
            {
                Debug.Log($"{nameof(_emptyTestObjectOnScene)} is NOT null.");
            }
            Debug.Log($"=ENDRESULT{_divider}");
        }
    }
}
