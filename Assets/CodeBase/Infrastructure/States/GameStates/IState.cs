namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}