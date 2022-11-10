using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Components.Enemy;
using Assets.Scripts.Metanoia.Services.Windows;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataMonstersPath = "StaticData/Monsters";
        private const string StaticDataLevelsPath = "StaticData/Levels";
        private const string StaticDataWindowsPath = "StaticData/UI/WindowData";

        private Dictionary<EnemyTypeId, EnemyStaticData> _monsters;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void Load()
        {
            _monsters = Resources
                .LoadAll<EnemyStaticData>(StaticDataMonstersPath)
                .ToDictionary(x => x.EnemyTypeId, x => x);

            _levels = Resources
                .LoadAll<LevelStaticData>(StaticDataLevelsPath)
                .ToDictionary(x => x.LevelKey, x => x);

            _windowConfigs = Resources
                .Load<WindowStaticData>(StaticDataWindowsPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public EnemyStaticData ForMonster(EnemyTypeId typeId) =>
            _monsters.TryGetValue(typeId, out EnemyStaticData staticData) ? staticData : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData) ? staticData : null;

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig) ? windowConfig : null;

    }
}
