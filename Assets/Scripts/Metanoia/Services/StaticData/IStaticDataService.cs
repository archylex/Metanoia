using Assets.Scripts.Metanoia.Components.Enemy;
using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Services.Windows;

namespace Assets.Scripts.Metanoia.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        EnemyStaticData ForMonster(EnemyTypeId typeId);
        LevelStaticData ForLevel(string sceneKey);
        WindowConfig ForWindow(WindowId shop);
    }
}
