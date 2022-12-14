using Assets.Scripts.Metanoia.Components.Health;
using System;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        private EnemyAnimator _animator;

        [SerializeField] private float _current;
        [SerializeField] private float _max;

        public event Action HealthChanged;

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        private void Awake() =>
            _animator = GetComponent<EnemyAnimator>();

        public void TakeDamage(float damage)
        {
            _current -= damage;
            _animator.PlayHit();

            HealthChanged?.Invoke();
        }
    }
}
