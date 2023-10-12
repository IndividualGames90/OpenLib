#if UNITY_EDITOR
using IndividualGames.OpenLib.Experimentation.UI;
using UnityEditor;
using UnityEngine;

namespace IndividualGames.OpenLib.Experimentation.Editor
{
    [CustomEditor(typeof(InventoryFactory))]
    public class InventoryFactoryButton : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Delete Item"))
            {
                Debug.Log("Button Pressed!");
                // Place your button logic here
            }
        }
    }
}
#endif