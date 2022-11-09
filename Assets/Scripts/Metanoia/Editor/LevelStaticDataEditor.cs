using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using Assets.Scripts.Metanoia.StaticData;
using Assets.Scripts.Metanoia.Components.Enemy;
using System.Linq;
using Assets.Scripts.Metanoia.Logic;

namespace Assets.Scripts.Metanoia.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string InitialPointTag = "InitialPoint";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.EnemySpawner =
                    FindObjectsOfType<SpawnMarker>()
                    .Select(x => new EnemySpawnerData(x.GetComponent<UniqueId>().Id, x.MonsterTypeId, x.transform.position))
                    .ToList();

                levelData.LevelKey = SceneManager.GetActiveScene().name;
                levelData.InitialHeroPosition = GameObject.FindWithTag(InitialPointTag).transform.position;
            }

            EditorUtility.SetDirty(target);
        }
    }
}
