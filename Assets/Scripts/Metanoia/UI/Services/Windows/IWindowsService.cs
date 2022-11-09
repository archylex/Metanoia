using Assets.Scripts.Metanoia.Services;

namespace Assets.Scripts.Metanoia.UI.Services.Windows
{
    public interface IWindowsService : IService
    {
        void Open(WindowId windowId);
    }
}
