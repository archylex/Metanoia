using Assets.Scripts.Metanoia.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Services.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public List<EnemySpawnerData> EnemySpawner;
        public Vector3 InitialHeroPosition;
    }
}
