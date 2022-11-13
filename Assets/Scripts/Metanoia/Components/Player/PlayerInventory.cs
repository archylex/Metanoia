using Assets.Scripts.Metanoia.Inventory;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public InventoryObject inventory;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            InventoryItemComponent item = other.GetComponent<InventoryItemComponent>();
            Debug.Log(item);
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject); 
            }

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Save Inventory");
                inventory.Save();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Load Inventory");
                inventory.Load();
            }
        }

        private void OnApplicationQuit()
        {
            inventory.Container.Items.Clear();
        }
    }
}
