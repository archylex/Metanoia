using Assets.Scripts.Metanoia.Services;

namespace Assets.Scripts.Metanoia.Services.Windows
{
    public interface IWindowsService : IService
    {
        void Open(WindowId windowId);
    }
}
