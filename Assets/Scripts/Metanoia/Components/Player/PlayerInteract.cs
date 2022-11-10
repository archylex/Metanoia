using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.Services.Input;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Player
{
    [RequireComponent(typeof(PlayerAnimator), typeof(CharacterController))]
    public class PlayerInteract : MonoBehaviour
    {
        [Range(0.01f, 10.0f)]
        public float InteractDistance = 1.0f;

        private IInputService _input;
        private RaycastHit[] _hits = new RaycastHit[1];
        private CharacterController _character;
        private static int _interactLayerMask;
        private bool _isEnabled = false;
        private FixedJoint joint;
        private PlayerMovement _playerMovement;
        private PlayerAnimator _animator;

        private void Awake()
        {        
            _character = GetComponent<CharacterController>();
            _playerMovement = GetComponent<PlayerMovement>();
            _animator = GetComponent<PlayerAnimator>();

            _input = GameServices.Container.Single<IInputService>();
            _interactLayerMask = 1 << LayerMask.NameToLayer("Interactable");
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(StartPoint(), StartPoint() + transform.forward * InteractDistance);
        }


        private void Update()
        {
            if (_input.IsInteractButtonDown()) _isEnabled = true;
            if (_input.IsInteractButtonUp()) _isEnabled = false;
            
            if (_isEnabled)
            {
                if (joint == null)
                {
                    int hits = Physics.RaycastNonAlloc(StartPoint(), transform.forward, _hits, InteractDistance, _interactLayerMask);
                    foreach (RaycastHit hit in _hits)
                    {
                        joint = hit.collider?.gameObject?.GetComponent<FixedJoint>();
                        if (joint != null)
                        {
                            joint.connectedBody = GetComponent<Rigidbody>();
                            joint.axis = hit.normal.normalized;
                            _playerMovement.SetDirectionClamper(hit.normal.normalized);
                            _animator.PlayPush(true);
                        }
                        Debug.Log(hit.collider?.gameObject?.name);
                        
                        //_playerMovement.enabled = false;
                    }
                    if (hits == 0)
                    {
                        Debug.Log("Did not hit");
                    }
                }
            } 
            else
            {
                if (joint != null)
                {
                    _animator.PlayPush(false);
                    joint.connectedBody = null;
                    joint = null;                    
                }

                for (int a = 0; a < _hits.Length; a++)
                {
                    _hits[a] = new RaycastHit();
                }

                _playerMovement.SetDirectionClamper(Vector3.one);
                
            }
        }
        private Vector3 StartPoint()
        {
            if (_character != null)
            {
                return new Vector3(transform.position.x, _character.center.y / 2, transform.position.z);
            }
            else
            {
                return Vector3.zero;
            }
        }
    }
}
