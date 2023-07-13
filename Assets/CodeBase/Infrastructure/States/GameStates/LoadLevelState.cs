namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private GameStateMachine _stateMachine;
        private readonly IInputService _inputService;

        public LoadLevelState(GameStateMachine gameStateMachine, IInputService inputService)
        {
            _stateMachine = gameStateMachine;
            _inputService = inputService;
        }

        public void Enter(string sceneName)
        {
        }

        public void Exit()
        {
        }
    }
}