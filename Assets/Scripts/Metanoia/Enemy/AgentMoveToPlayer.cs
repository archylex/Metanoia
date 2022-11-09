using UnityEngine.AI;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToPlayer : Follow
    {
        [SerializeField]
        private float MinimalDistance = 3.0f;

        private NavMeshAgent _agent;
        private Transform _playerTransform;

        public void Construct(Transform playerTransform) =>
            _playerTransform = playerTransform;

        private void Awake() =>
            _agent = GetComponent<NavMeshAgent>();

        private void Update()
        {
            if (Initialized() && PlayerNotReached())
                _agent.destination = _playerTransform.position;
        }

        private bool Initialized() =>
            _playerTransform != null;

        private bool PlayerNotReached() =>
            (_agent.transform.position - _playerTransform.position).magnitude >= MinimalDistance;
    }
}
