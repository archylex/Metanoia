using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.Services.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Save
{
    [RequireComponent(typeof(BoxCollider))]
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;

        private BoxCollider _collider;

        private void Awake()
        {
            _saveLoadService = GameServices.Container.Single<ISaveLoadService>();
            _collider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            Debug.Log("Progress Saved.");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!_collider)
                return;

            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}
