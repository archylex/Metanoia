using Assets.Scripts.Metanoia.Animation;
using System;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Player
{
    public class PlayerAnimator : MonoBehaviour, IAnimationStateReader
    {
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int GroundHash = Animator.StringToHash("Ground");
        private static readonly int HitHash = Animator.StringToHash("Hit");
        private static readonly int DieHash = Animator.StringToHash("Die");
        private static readonly int PushHash = Animator.StringToHash("Push");

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _attackStateHash = Animator.StringToHash("Attack");
        private readonly int _walkingStateHash = Animator.StringToHash("Move");
        private readonly int _jumpStateHash = Animator.StringToHash("Jump");
        private readonly int _deathStateHash = Animator.StringToHash("Die");

        private Animator _animator;
        private CharacterController _characterController;

        private bool _isJump = false;

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;
        public AnimatorState State { get; private set; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {            
            _animator.SetBool(GroundHash, _characterController.isGrounded);

            if (!_characterController.isGrounded && !_isJump)
            {
                _isJump = true;
                _animator.SetTrigger(JumpHash);
            }

            if (_characterController.isGrounded)
            {
                _isJump = false;
                _animator.SetFloat(SpeedHash, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
            }             
        }

        public bool IsAttacking => State == AnimatorState.Attack;

        public void PlayHit() => _animator.SetTrigger(HitHash);

        public void PlayAttack() => _animator.SetTrigger(AttackHash);

        public void PlayPush(bool isEnabled) => _animator.SetBool(PushHash, isEnabled);

        public void PlayDeath() => _animator.SetTrigger(DieHash);

        public void ResetToIdle() => _animator.Play(_idleStateHash, -1);

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash) =>
          StateExited?.Invoke(StateFor(stateHash));

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == _idleStateHash)
                state = AnimatorState.Idle;
            else if (stateHash == _attackStateHash)
                state = AnimatorState.Attack;
            else if (stateHash == _walkingStateHash)
                state = AnimatorState.Walking;
            else if (stateHash == _deathStateHash)
                state = AnimatorState.Died;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}
