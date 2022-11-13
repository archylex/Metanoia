using UnityEngine;

namespace Assets.Scripts.Metanoia.Inventory
{
    [CreateAssetMenu(fileName = "FoodObject", menuName = "Inventory System/Items/Food")]
    public class FoodObject : ItemObject
    {
        private void Awake()
        {
            type = ItemType.Food;
        }
    }
}
