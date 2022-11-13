using Assets.Scripts.Metanoia.Inventory;
using System;

namespace Assets.Scripts.Metanoia.Data
{
    [Serializable]
    public class ItemBuff
    {
        public InventoryItemAttributes attributes;
        public int value;
        public int min;
        public int max;

        public ItemBuff(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public void GenerateValue()
        {
            value = UnityEngine.Random.Range(min, max);
        }
    }
}
