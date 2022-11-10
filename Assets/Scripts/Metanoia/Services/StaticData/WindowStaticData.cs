using Assets.Scripts.Metanoia.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Services.StaticData
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "StaticData/WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}
