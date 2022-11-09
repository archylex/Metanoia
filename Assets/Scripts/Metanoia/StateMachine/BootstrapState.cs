using Assets.Scripts.Metanoia.AssetManagement;
using Assets.Scripts.Metanoia.Factory;
using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.Services.Ads;
using Assets.Scripts.Metanoia.Services.IAP;
using Assets.Scripts.Metanoia.Services.Input;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using Assets.Scripts.Metanoia.Services.Random;
using Assets.Scripts.Metanoia.Services.SaveLoad;
using Assets.Scripts.Metanoia.StaticData;
using Assets.Scripts.Metanoia.UI.Services.Factory;
using Assets.Scripts.Metanoia.UI.Services.Windows;
using UnityEngine;

namespace Assets.Scripts.Metanoia.StateMachine
{
    public class BootstrapState : IState
    {
        private const string InitScene = "Bootstrap";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly GameServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, GameServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter() =>
            _sceneLoader.Load(InitScene, onLoaded: EnterLoadLevel);

        public void Exit()
        {
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            RegisterStaticDataService();
            RegisterRandomService();
            RegisterAdsService();

            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            _services.RegisterSingle(RegisterInputService());
            RegisterAssetProviderService();
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            RegisterIAPService(new IAPProvider(), _services.Single<IPersistentProgressService>());

            _services.RegisterSingle<IUIFactory>(new UIFactory(
                _services.Single<IAssets>(),
                _services.Single<IStaticDataService>(),
                _services.Single<IPersistentProgressService>(),
                _services.Single<IAdsService>(),
                _services.Single<IIAPService>()));

            _services.RegisterSingle<IWindowsService>(new WindowsService(
            _services.Single<IUIFactory>()));

            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IAssets>(),
                _services.Single<IStaticDataService>(),
                _services.Single<IRandomService>(),
                _services.Single<IPersistentProgressService>(),
                _services.Single<IWindowsService>()));

            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(
                _services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>()));
        }

        private void RegisterAssetProviderService()
        {
            IAssets assetProvider = new AssetProvider();
            assetProvider.Initialize();
            _services.RegisterSingle(assetProvider);
        }

        private void RegisterAdsService()
        {
            IAdsService adsService = new AdsService();
            adsService.Initialize();
            _services.RegisterSingle(adsService);
        }

        private void RegisterIAPService(IAPProvider iapProvider, IPersistentProgressService progressService)
        {
            IIAPService iapService = new IAPService(iapProvider, progressService);

            iapService.Initialize();
            _services.RegisterSingle(iapService);
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }

        private void RegisterRandomService()
        {
            IRandomService randomService = new UnityRandomService();
            _services.RegisterSingle(randomService);
        }

        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            return new MobileInputService();
        }
    }
}
