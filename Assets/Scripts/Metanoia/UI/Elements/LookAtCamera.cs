using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Metanoia.UI.Elements
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _camera;

        private void Start() =>
            _camera = Camera.main;

        private void Update()
        {
            Quaternion rotation = _camera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }
    }
}
