using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Components.Health;
using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.Services.Input;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Player
{
    [RequireComponent(typeof(PlayerAnimator), typeof(CharacterController))]
    public class PlayerAttack : MonoBehaviour, ISavedProgressReader
    {
        private PlayerAnimator _animator;
        private CharacterController _character;
        private IInputService _input;

        private static int _layerMask;
        private Collider[] _hits = new Collider[3];
        private Stats _stats;

        private void Awake()
        {
            _animator = GetComponent<PlayerAnimator>();
            _character = GetComponent<CharacterController>();

            _input = GameServices.Container.Single<IInputService>();
            _layerMask = 1 << LayerMask.NameToLayer("Enemy");
        }

        private void Update()
        {
            if (_input.IsAttackButton() && !_animator.IsAttacking)
            {
                _animator.PlayAttack();
            }                        
        }

        public void OnAttack()
        {
            for (int i = 0; i < Hit(); i++)
            {
                _hits[i].transform.parent.GetComponent<IHealth>()?.TakeDamage(_stats.Damage);
            }
        }

        public void LoadProgress(PlayerProgress progress) =>
            _stats = progress.HeroStats;
        private int Hit() =>
            Physics.OverlapSphereNonAlloc(StartPoint() + transform.forward, _stats.Radius, _hits, _layerMask);

        private Vector3 StartPoint() =>
            new Vector3(transform.position.x, _character.center.y / 2, transform.position.z);
    }
}
