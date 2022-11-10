using Assets.Scripts.Metanoia.Components.Enemy;
using System;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Data
{
    [Serializable]
    public class EnemySpawnerData
    {
        public string Id;
        public EnemyTypeId MonsterTypeId;
        public Vector3 Position;

        public EnemySpawnerData(string id, EnemyTypeId monsterTypeId, Vector3 position)
        {
            Id = id;
            MonsterTypeId = monsterTypeId;
            Position = position;
        }
    }
}
