using Assets.Scripts.Metanoia.Components.Enemy;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Services.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        [Range(1, 100)] public int Hp;
        [Range(1f, 30f)] public float Damage;
        [Range(1f, 30f)] public float Speed;
        [Range(0.5f, 1f)] public float EffectiveDistance;
        [Range(0.5f, 1f)] public float Cleavage;
        public AssetReferenceGameObject PrefabReference;

        public int MaxLoot;
        public int MinLoot;
    }
}
