using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Metanoia.StaticData.Windows
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "StaticData/WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}
