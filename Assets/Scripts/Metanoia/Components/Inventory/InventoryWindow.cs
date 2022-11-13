using Assets.Scripts.Metanoia.Components.Shop;
using Assets.Scripts.Metanoia.Components.Window;
using Assets.Scripts.Metanoia.Services.AssetManagement;
using Assets.Scripts.Metanoia.Services.IAP;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using TMPro;

namespace Assets.Scripts.Metanoia.Components.Inventory
{
    public class InventoryWindow : WindowBase
    {
        public InventoryItemsContainer InventoryItemsContainer;

        public void Construct(
            IPersistentProgressService progressService,
            IAssets asset)
        {
            base.Construct(progressService);
            InventoryItemsContainer.Construct(progressService, asset);
        }

        protected override void Initialize()
        {
            InventoryItemsContainer.Initialize();
        }

        protected override void SubscribeUpdates()
        {
            InventoryItemsContainer.Subscribe();
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            InventoryItemsContainer.Cleanup();
        }
    }
}
