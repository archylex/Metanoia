using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Metanoia.Inventory
{
    public class DisplayInventory : MonoBehaviour, ISavedProgress
    {
        public GameObject inventoryPrefab;
        public InventoryObject inventory;

        Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

        private void Start()
        {
            CreateDisplay();
        }

        private void Update()
        {

        }

        public void LoadProgress(PlayerProgress progress)
        {
            Debug.Log("LoadProgressInv");
            progress.Inventory.Load();            
        }


        private void CreateDisplay()
        {
            foreach(InventorySlot slot in inventory.Container.Items)
            {
                GameObject slotObject = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                slotObject.transform.GetChild(0).GetComponent<Image>().sprite = slot.item.uiSprite;
                
            }
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.Inventory.Save();
        }
    }
}
