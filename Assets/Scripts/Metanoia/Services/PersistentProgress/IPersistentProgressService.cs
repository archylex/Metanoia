using Assets.Scripts.Metanoia.Data;

namespace Assets.Scripts.Metanoia.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}
