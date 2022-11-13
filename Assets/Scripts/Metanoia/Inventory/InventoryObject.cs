using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Utils;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Inventory
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
    {
        public Inventory Container;

        private InventoryItemData database;

        private void OnEnable()
        {
            //database = (InventoryItemData)AssetDatabase.LoadAssetAtPath("Assets/Resources/StaticData/Inventory/InventoryDB.asset", typeof(InventoryItemData));
            database = Resources.Load<InventoryItemData>("StaticData/Inventory/InventoryDB");
        }

        public void AddItem(ItemObject item, int amount)
        {            
            for (int i = 0; i < Container.Items.Count; ++i)
            {
                if (Container.Items[i].item == item)
                {
                    Container.Items[i].AddAmount(amount);
                    return;
                }
            }

            Container.Items.Add(new InventorySlot(database.GetId[item], item, amount));
        }

        public void OnAfterDeserialize()
        {
            foreach (InventorySlot slot in Container.Items)
            {
                slot.item = database.GetItemById(slot.id);
            }
        }

        public void OnBeforeSerialize()
        {
            
        }

        public void Save()
        {
            string json = this.ToJson();
            PlayerPrefs.SetString("inventory", json);
        }

        public void Load()
        {
            string json = PlayerPrefs.GetString("inventory");
            JsonUtility.FromJsonOverwrite(json, this);            
        }
    }   
}
