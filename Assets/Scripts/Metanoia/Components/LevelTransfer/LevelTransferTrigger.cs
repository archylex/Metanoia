using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.StateMachine;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.LevelTransfer
{
    public class LevelTransferTrigger : MonoBehaviour
    {
        public string TransferTo;

        private const string PlayerTag = "Player";
        private IGameStateMachine _stateMachine;
        private bool _triggered;
        private void Awake() =>
            _stateMachine = GameServices.Container.Single<IGameStateMachine>();

        private void OnTriggerEnter(Collider other)
        {
            if (_triggered)
                return;

            if (other.CompareTag(PlayerTag))
            {
                _stateMachine.Enter<LoadLevelState, string>(TransferTo);
                _triggered = true;
            }
        }
    }
}
