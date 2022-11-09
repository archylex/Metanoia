using Assets.Scripts.Metanoia.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        private EnemyAnimator _animator;

        [SerializeField] private float _current;
        [SerializeField] public float _max;

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
