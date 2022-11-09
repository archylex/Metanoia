using UnityEngine;

namespace Assets.Scripts.Metanoia.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButton();

        bool IsInteractButtonDown();

        bool IsInteractButtonUp();

        bool IsJumpButton();
    }
}
