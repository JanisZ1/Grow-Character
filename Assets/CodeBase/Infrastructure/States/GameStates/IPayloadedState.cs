namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}