using Assets.Scripts.Metanoia.Components.Curtain;
using Assets.Scripts.Metanoia.Services;
using Assets.Scripts.Metanoia.StateMachine;
using Unity.VisualScripting;

namespace Assets.Scripts.Metanoia
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain) =>
            StateMachine = CreateStateMachine(CreateSceneLoader(coroutineRunner), curtain);
        
        private SceneLoader CreateSceneLoader(ICoroutineRunner coroutineRunner) =>
            new SceneLoader(coroutineRunner);

        private GameStateMachine CreateStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain) =>
            new GameStateMachine(sceneLoader, curtain, GameServices.Container);
        
    }
}
