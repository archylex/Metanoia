using System;

namespace Assets.Scripts.Metanoia.Inventory
{
    [Serializable]
    public class InventorySlot
    {
        public int id;
        public ItemObject item;
        public int amount;

        public InventorySlot(int id, ItemObject item, int amount)
        {
            this.id = id;
            this.item = item;
            this.amount = amount;
        }

        public void AddAmount(int value)
        {
            amount += value;
        }
    }
}
