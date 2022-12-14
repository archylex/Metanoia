using Assets.Scripts.Metanoia.Components.Camera;
using Assets.Scripts.Metanoia.Components.Curtain;
using Assets.Scripts.Metanoia.Factory;
using Assets.Scripts.Metanoia.Services.StaticData;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using Assets.Scripts.Metanoia.Components.Player;
using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Components.Enemy;
using Assets.Scripts.Metanoia.Components.Health;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Service.StateMachine
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IStaticDataService _staticData;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(
            GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            LoadingCurtain curtain,
            IGameFactory gameFactory,
            IPersistentProgressService progressService,
            IStaticDataService staticData,
            IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _staticData = staticData;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain?.Show();
            _gameFactory.CleanUp();
            _gameFactory.WarmUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _curtain?.Hide();

        private async void OnLoaded()
        {
            await InitUIRoot();
            await InitGameWorld();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private async Task InitUIRoot() =>
            await _uiFactory.CreateUIRoot();

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        private async Task InitGameWorld()
        {
            LevelStaticData levelData = LevelStaticData();

            await InitSpawners(levelData);
            GameObject hero = await InitHero(levelData);
            await InitHud(hero);
            await InitUnpickedLoot();

            CameraFollow(hero);
        }

        private async Task<GameObject> InitHero(LevelStaticData levelStaticData) =>
            await _gameFactory.CreateHero(levelStaticData.InitialHeroPosition);

        private async Task InitSpawners(LevelStaticData levelStaticData)
        {
            foreach (EnemySpawnerData spawnerData in levelStaticData.EnemySpawner)
                await _gameFactory.CreateSpawner(spawnerData.Position, spawnerData.Id, spawnerData.MonsterTypeId);
        }

        private async Task InitHud(GameObject hero)
        {
            GameObject hud = await _gameFactory.CreateHud();
            hud.GetComponentInChildren<HpBar>().Construct(hero.GetComponent<PlayerHealth>());
        }

        private void CameraFollow(GameObject hero) =>
            Camera.main.GetComponent<CameraFollow>().Follow(hero);

        private LevelStaticData LevelStaticData() =>
            _staticData.ForLevel(SceneManager.GetActiveScene().name);

        private async Task InitUnpickedLoot()
        {
            foreach (var lootItem in _progressService.Progress.WorldData.LootData.UnpickedLoot.Loot)
            {
                LootPiece lootPiece = await _gameFactory.CreateLoot();
                lootPiece.Initialize(lootItem);
            }
        }
    }
}
