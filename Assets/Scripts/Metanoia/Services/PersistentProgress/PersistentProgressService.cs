using Assets.Scripts.Metanoia.Data;

namespace Assets.Scripts.Metanoia.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}
