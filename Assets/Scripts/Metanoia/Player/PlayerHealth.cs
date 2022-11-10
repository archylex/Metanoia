using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Components.Health;
using Assets.Scripts.Metanoia.Services.PersistentProgress;
using System;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerHealth : MonoBehaviour, ISavedProgress, IHealth
    {
        private PlayerAnimator _animator;
        private State _state;

        public event Action HealthChanged;

        public float Max
        {
            get => _state.MaxHP;
            set => _state.MaxHP = value;
        }

        public float Current
        {
            get => _state.CurrentHP;
            set
            {
                if (_state.CurrentHP != value)
                {
                    _state.CurrentHP = value;
                    HealthChanged?.Invoke();
                }
            }
        }

        private void Awake() =>
            _animator = GetComponent<PlayerAnimator>();

        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.HeroState;
            HealthChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HeroState.CurrentHP = Current;
            progress.HeroState.MaxHP = Max;
        }

        public void TakeDamage(float damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
            _animator.PlayHit();
        }
    }
}
