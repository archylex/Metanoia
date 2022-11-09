using Assets.Scripts.Metanoia.Data;

namespace Assets.Scripts.Metanoia.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}
