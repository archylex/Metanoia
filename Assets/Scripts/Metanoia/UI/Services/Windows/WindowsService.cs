using Assets.Scripts.Metanoia.UI.Services.Factory;
using UnityEngine; 

namespace Assets.Scripts.Metanoia.UI.Services.Windows
{
    public class WindowsService : IWindowsService
    {
        private readonly IUIFactory _uiFactory;

        public WindowsService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Open(WindowId windowId)
        {            
            switch (windowId)
            {
                case WindowId.Unknown:
                    break;
                case WindowId.Shop:
                    _uiFactory.CreateShop();
                    break;
            }
        }
    }
}
