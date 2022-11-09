using UnityEngine;

namespace Assets.Scripts.Metanoia.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string AttackButton = "Attack";
        private const string InteractButton = "Interact";
        private const string JumpButton = "Jump";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButton() =>
            SimpleInput.GetButtonDown(AttackButton);

        public bool IsInteractButtonDown() =>
            SimpleInput.GetButtonDown(InteractButton);

        public bool IsInteractButtonUp() =>
            SimpleInput.GetButtonUp(InteractButton);

        public bool IsJumpButton() =>
            SimpleInput.GetButtonDown(JumpButton);

        protected static Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}
