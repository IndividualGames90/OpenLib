using UnityEngine;

namespace IndividualGames.OpenLib.Experimentation.UI
{
    /// <summary>
    /// Holds the inventory item to be placed on the grid.
    /// </summary>
    [CreateAssetMenu(fileName = "InventoryItemData", menuName = "OpenLib/Data/UI/InventoryItemData")]
    public class InventoryItemData : ScriptableObject
    {
        [SerializeField] public GameObject[] inventoryItems;
    }
}