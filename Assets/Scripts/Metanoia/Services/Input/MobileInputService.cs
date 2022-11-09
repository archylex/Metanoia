using UnityEngine;

namespace Assets.Scripts.Metanoia.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}
