using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndividualGames.OpenLib.Tests.PlayMode
{
    /// <summary>
    /// Integration test for SingletonComponent
    /// </summary>
    public class SingletonComponentTest : SingletonComponent<SingletonComponentTest>
    {
        [SerializeField] private SceneAsset _thisScene;

        public enum TestStageEnum
        {
            UnityAwake,
            SubstituteAwake
        }

        public TestStageEnum TestStage;

        private void Awake()
        {
            Debug.Log(TestStageEnum.UnityAwake);

            MustCallInAwake(AwakeTest);

            StartCoroutine(TestAfterDelay());
        }

        private void AwakeTest()
        {
            Debug.Log(TestStageEnum.SubstituteAwake);
        }

        #region Test

        private IEnumerator TestAfterDelay()
        {
            yield return new WaitForSeconds(2);

            SceneManager.LoadScene(_thisScene.name, LoadSceneMode.Single);
        }

        #endregion
    }
}
