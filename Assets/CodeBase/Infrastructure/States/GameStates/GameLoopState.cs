using Assets.CodeBase.Infrastructure.Services.PlayerLearn;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class GameLoopState : IState
    {
        private GameStateMachine _gameStateMachine;
        private readonly IPlayerLearnService _playerLearnService;

        public GameLoopState(GameStateMachine gameStateMachine, IPlayerLearnService playerLearnService)
        {
            _gameStateMachine = gameStateMachine;
            _playerLearnService = playerLearnService;
        }

        public void Enter()
        {
            if (_playerLearnService.NewPlayerLoaded)
                _playerLearnService.StartLearn();
        }

        public void Exit()
        {
        }
    }
}