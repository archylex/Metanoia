using Assets.Scripts.Metanoia.UI.Services.Windows;
using Assets.Scripts.Metanoia.UI.Windows;
using System;

namespace Assets.Scripts.Metanoia.StaticData.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}
