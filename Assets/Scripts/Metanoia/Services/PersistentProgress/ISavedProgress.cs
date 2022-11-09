using Assets.Scripts.Metanoia.Data;

namespace Assets.Scripts.Metanoia.Services.PersistentProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}
