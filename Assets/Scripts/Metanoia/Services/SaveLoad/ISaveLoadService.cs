using Assets.Scripts.Metanoia.Data;

namespace Assets.Scripts.Metanoia.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}
