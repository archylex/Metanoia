using Assets.Scripts.Metanoia.Services;
using System.Threading.Tasks;

namespace Assets.Scripts.Metanoia.Factory
{
    public interface IUIFactory : IService
    {
        void CreateShop();
        void CreateInventory();
        Task CreateUIRoot();
    }
}
