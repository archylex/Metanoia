using Assets.Scripts.Metanoia.Services.AssetManagement;
using Assets.Scripts.Metanoia.Services.Ads;
using Assets.Scripts.Metanoia.Services.IAP;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using Assets.Scripts.Metanoia.Components.Window;
using TMPro;

namespace Assets.Scripts.Metanoia.Components.Shop
{
    public class ShopWindow : WindowBase
    {
        public TextMeshProUGUI SkullText;
        public RewardedAdItem AdItem;
        public ShopItemsContainer ShopItemsContainer;

        public void Construct(
            IAdsService adsService,
            IPersistentProgressService progressService,
            IIAPService iapService,
            IAssets asset)
        {
            base.Construct(progressService);
            AdItem.Construct(adsService, progressService);
            ShopItemsContainer.Construct(iapService, progressService, asset);
        }

        protected override void Initialize()
        {
            AdItem.Initialize();
            ShopItemsContainer.Initialize();
            RefreshSkullText();
        }

        protected override void SubscribeUpdates()
        {
            AdItem.Subscribe();
            ShopItemsContainer.Subscribe();
            Progress.WorldData.LootData.Changed += RefreshSkullText;
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            AdItem.Cleanup();
            ShopItemsContainer.Cleanup();
            Progress.WorldData.LootData.Changed -= RefreshSkullText;
        }

        private void RefreshSkullText()
        {
            //SkullText.text = Progress.WorldData.LootData.Collected.ToString();
        }
    }
}
