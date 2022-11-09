using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.StaticData.Windows;
using Assets.Scripts.Metanoia.UI.Services.Windows;

namespace Assets.Scripts.Metanoia.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        MonsterStaticData ForMonster(MonsterTypeId typeId);
        LevelStaticData ForLevel(string sceneKey);
        WindowConfig ForWindow(WindowId shop);
    }
}
