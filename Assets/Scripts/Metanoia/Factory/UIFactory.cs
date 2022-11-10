using Assets.Scripts.Metanoia.Services.AssetManagement;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using Assets.Scripts.Metanoia.Services.Ads;
using Assets.Scripts.Metanoia.Services.IAP;
using Assets.Scripts.Metanoia.Services.StaticData;
using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Components.Shop;
using Assets.Scripts.Metanoia.Services.Windows;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UIRoot";

        private readonly IAssets _asset;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;
        private readonly IAdsService _adService;
        private readonly IIAPService _iapService;

        private Transform _uiRoot;

        public UIFactory(
            IAssets asset,
            IStaticDataService staticData,
            IPersistentProgressService progressService,
            IAdsService adService,
            IIAPService iapService)
        {
            _asset = asset;
            _staticData = staticData;
            _progressService = progressService;
            _adService = adService;
            _iapService = iapService;
        }

        public void CreateShop()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Shop);
            ShopWindow window = Object.Instantiate(config.Prefab, _uiRoot) as ShopWindow;
            window.Construct(_adService, _progressService, _iapService, _asset);
        }

        public async Task CreateUIRoot()
        {
            GameObject root = await _asset.Instantiate(UIRootPath);
            _uiRoot = root.transform;
        }
    }
}
