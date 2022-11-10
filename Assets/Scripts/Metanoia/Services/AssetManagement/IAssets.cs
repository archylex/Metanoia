using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Services.AssetManagement
{
    public interface IAssets : IService
    {
        void Initialize();
        Task<T> Load<T>(AssetReference assetReference) where T : class;
        Task<T> Load<T>(string address) where T : class;
        Task<GameObject> Instantiate(string path);
        Task<GameObject> Instantiate(string path, Vector3 at);
        void CleanUp();
        Task<GameObject> Instantiate(string address, Transform under);
    }
}
