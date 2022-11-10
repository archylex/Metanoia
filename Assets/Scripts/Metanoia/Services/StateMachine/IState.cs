namespace Assets.Scripts.Metanoia.Service.StateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}
