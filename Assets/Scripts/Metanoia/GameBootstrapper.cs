using Assets.Scripts.Metanoia.Components.Curtain;
using Assets.Scripts.Metanoia.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Metanoia
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] 
        private LoadingCurtain _curtainPrefab = null;

        private Game _game;

        private void Awake()
        {
            LoadingCurtain curtain = _curtainPrefab ? Instantiate(_curtainPrefab) : null;

            _game = new Game(this, curtain);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }

    }
}
