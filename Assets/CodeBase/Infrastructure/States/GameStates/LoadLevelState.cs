namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private GameStateMachine _stateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine) =>
            _stateMachine = gameStateMachine;

        public void Enter(string sceneName)
        {
        }

        public void Exit()
        {
        }
    }
}