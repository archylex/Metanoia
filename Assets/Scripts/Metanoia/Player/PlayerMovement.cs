using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Metanoia.Player
{
    public class PlayerMovement : MonoBehaviour
    {        
        public float Speed;
        public float JumpSpeed;

        private IInputService _inputService;
        private Camera _camera;
        private CharacterController _characterController;
        private float _speedY = 0.0f;
        private float _originalStepOffset;
        private Vector3 directionClamper = Vector3.one;

        private void Awake()
        {
            _inputService = GameServices.Container.Single<IInputService>();

            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _camera = Camera.main;
            _originalStepOffset = _characterController.stepOffset;
        }

        private void Update()
        {
            Vector3 direction = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                direction = _camera.transform.TransformDirection(_inputService.Axis);
                direction.y = 0;
                direction.Normalize();

                if (directionClamper.Equals(Vector3.one))
                    transform.forward = direction;
                else
                    transform.forward = directionClamper * -1;

            }

            if (_characterController.isGrounded)
            {
                _characterController.stepOffset = _originalStepOffset;
                _speedY = -0.5f;

                if (_inputService.IsJumpButton())
                {
                    _speedY = JumpSpeed;
                    Debug.Log("Jump");
                }
            }
            else
            {
                _characterController.stepOffset = 0;
            }

            _speedY += Physics.gravity.y * Time.deltaTime;

            float velocity = _inputService.Axis.magnitude * Speed;

            Vector3 movementVelocity = velocity * direction;            
            movementVelocity = movementVelocity.Multiply(directionClamper.Abs());
            movementVelocity.y = _speedY;

            _characterController.Move(movementVelocity * Time.deltaTime);
        }

        public void SetDirectionClamper(Vector3 vec) => directionClamper = vec;

        public void UpdateProgress(PlayerProgress progress) =>
            progress.WorldData.PositionOnLevel =
                new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());

        private static string CurrentLevel() =>
            SceneManager.GetActiveScene().name;

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
                if (savedPosition != null)
                    Warp(to: savedPosition);
            }
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.AsUnityVector().AddY(_characterController.height);
            _characterController.enabled = true;
        }
    }
}
