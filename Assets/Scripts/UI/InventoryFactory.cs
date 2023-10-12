using IndividualGames.OpenLib.Pattern;
using UnityEngine;

namespace IndividualGames.OpenLib.Experimentation.UI
{
    public sealed class InventoryFactory : MonoBehaviour, IGameObjectFactory
    {
        [SerializeField] private GameObject grid;
        [SerializeField] private bool initilizeRandomTest;
        [SerializeField] private int randomElementCount;
        [SerializeField] private InventoryItemData itemData;

        private void Awake()
        {
            if (initilizeRandomTest)
            {
                for (int i = 0; i < randomElementCount; i++)
                {
                    var index = UnityEngine.Random.Range(0, itemData.inventoryItems.Length);
                    var item = Instantiate(itemData.inventoryItems[index]);
                    item.transform.parent = grid.transform;
                }
            }
        }

        public GameObject Create(int itemIndex)
        {
            var item = Instantiate(itemData.inventoryItems[itemIndex]);
            item.transform.parent = grid.transform;
            return item;
        }

        void IFactory.Create(int key)
        {
            throw new System.NotImplementedException();
        }
    }
}