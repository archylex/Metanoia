using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Data
{
    [CreateAssetMenu(fileName = "InventoryDB", menuName = "Inventory System/Items/Database")]
    public class InventoryItemData : ScriptableObject, ISerializationCallbackReceiver
    {
        public ItemObject[] Items;
        public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();

        public void OnAfterDeserialize()
        {
            GetId = new Dictionary<ItemObject, int>();

            for (int i = 0; i < Items.Length; ++i)
            {
                GetId.Add(Items[i], i);
            }
        }

        public ItemObject GetItemById(int id) => GetId.FirstOrDefault(x => x.Value == id).Key;

        public void OnBeforeSerialize()
        {
            
        }
    }
}
