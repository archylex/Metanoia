using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Factory;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Enemy
{
    public class SpawnPoint : MonoBehaviour, ISavedProgress
    {
        public EnemyTypeId enemyType;
        public string Id { get; set; }

        public bool slain;

        private IGameFactory _gameFactory;
        private EnemyDeath _enemyDeath;

        public void Construct(IGameFactory factory) =>
            _gameFactory = factory;

        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.KillData.ClearedSpawners.Contains(Id))
                slain = true;
            else
                Spawn();
        }

        private async void Spawn()
        {
            GameObject enemy = await _gameFactory.CreateMonster(enemyType, transform);
            _enemyDeath = enemy.GetComponent<EnemyDeath>();
            _enemyDeath.Happened += Slay;
        }

        private void Slay()
        {
            if (_enemyDeath != null)
                _enemyDeath.Happened -= Slay;

            slain = true;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            if (slain)
                progress.KillData.ClearedSpawners.Add(Id);
        }
    }
}
