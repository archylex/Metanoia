using Assets.Scripts.Metanoia.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Metanoia.UI.Elements
{
    public class OpenWindowButton : MonoBehaviour
    {
        public Button Button;
        public WindowId WindowId;

        private IWindowsService _windowsService;

        public void Construct(IWindowsService windowsService) =>
            _windowsService = windowsService;

        private void Awake() =>
            Button.onClick.AddListener(Open);

        private void Open() =>
            _windowsService.Open(WindowId);
    }
}
