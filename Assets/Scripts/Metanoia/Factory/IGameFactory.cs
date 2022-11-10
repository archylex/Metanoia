using Assets.Scripts.Metanoia.Components.Enemy;
using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Factory
{
    public interface IGameFactory : IService
    {
        Task<GameObject> CreateHero(Vector3 at);
        Task<GameObject> CreateHud();
        Task<GameObject> CreateMonster(EnemyTypeId typeId, Transform parent);
        Task<LootPiece> CreateLoot();
        Task CreateSpawner(Vector3 at, string spawnerId, EnemyTypeId monsterTypeId);
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        Task WarmUp();
        void CleanUp();
    }
}
