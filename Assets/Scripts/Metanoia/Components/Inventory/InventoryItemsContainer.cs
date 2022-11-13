using Assets.Scripts.Metanoia.Services.AssetManagement;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Inventory
{
    public class InventoryItemsContainer : MonoBehaviour
    {
        private const string InventoryItemPath = "InventoryItem";
                
        public Transform Parent;
                
        private IPersistentProgressService _progressService;
        private IAssets _asset;

        private readonly List<GameObject> _inventoryItems = new List<GameObject>();

        public void Construct(
            IPersistentProgressService progressService,
            IAssets asset)
        {
            _progressService = progressService;
            _asset = asset;
        }

        public void Initialize() =>
            RefreshAvailableItems();

        public void Subscribe()
        {
            //_progressService.Progress.Inventory.Changed += RefreshAvailableItems;
        }

        public void Cleanup()
        {
            //_progressService.Progress.Inventory.Changed -= RefreshAvailableItems;
        }

        private async void RefreshAvailableItems()
        {
            ClearInventoryItems();

            await FillInventoryItems();
        }

        private void ClearInventoryItems()
        {
            foreach (GameObject inventoryItem in _inventoryItems)
                Destroy(inventoryItem);
        }

        private async Task FillInventoryItems()
        {
            
                /*GameObject itemObject = await _asset.Instantiate(InventoryItemPath, Parent);
                ShopItem shopItem = itemObject.GetComponent<ShopItem>();
                shopItem.Construct(_iapService, _asset, productDescription);
                shopItem.Initialize();
                _shopItems.Add(itemObject);*/
            
        }
    }
}
