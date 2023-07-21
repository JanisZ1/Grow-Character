namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadProgressState : IState
    {
        private GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine) =>
            _gameStateMachine = gameStateMachine;

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}