﻿using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Camera
{
    public class LookAtCamera : MonoBehaviour
    {
        private UnityEngine.Camera _camera;

        private void Start() =>
            _camera = UnityEngine.Camera.main;

        private void Update()
        {
            Quaternion rotation = _camera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }
    }
}
