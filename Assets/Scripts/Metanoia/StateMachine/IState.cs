namespace Assets.Scripts.Metanoia.StateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}
