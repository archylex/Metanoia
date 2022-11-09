using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(PlayerAttack))]
    [RequireComponent(typeof(PlayerMovement))]
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private GameObject _deathFX = null;

        private PlayerHealth _health;
        private PlayerMovement _move;
        private PlayerAttack _attack;
        private PlayerAnimator _animator;

        private bool _isDead;

        private void Awake()
        {
            _health = GetComponent<PlayerHealth>();
            _move = GetComponent<PlayerMovement>();
            _attack = GetComponent<PlayerAttack>();
            _animator = GetComponent<PlayerAnimator>();
        }

        private void Start() =>
            _health.HealthChanged += HealthChange;

        private void OnDestroy() =>
            _health.HealthChanged -= HealthChange;

        private void HealthChange()
        {
            if (!_isDead && _health.Current <= 0f)
                Die();
        }

        private void Die()
        {
            _isDead = true;

            _move.enabled = false;
            _attack.enabled = false;
            _animator.PlayDeath();

            Instantiate(_deathFX, transform.position, Quaternion.identity);
        }
    }
}
