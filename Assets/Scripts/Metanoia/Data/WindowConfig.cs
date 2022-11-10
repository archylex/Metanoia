using Assets.Scripts.Metanoia.Services.Windows;
using Assets.Scripts.Metanoia.Components.Window;
using System;

namespace Assets.Scripts.Metanoia.Data
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}
