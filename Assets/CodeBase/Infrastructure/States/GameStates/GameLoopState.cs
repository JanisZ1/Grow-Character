namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class GameLoopState : IState
    {
        private GameStateMachine _gameStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine) =>
            _gameStateMachine = gameStateMachine;

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}