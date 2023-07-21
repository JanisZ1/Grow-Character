using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadProgressState : IState
    {
        private GameStateMachine _gameStateMachine;
        private readonly IPlayerProgressService _playerProgressService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPlayerProgressService playerProgressService)
        {
            _gameStateMachine = gameStateMachine;
            _playerProgressService = playerProgressService;
        }

        public void Enter() =>
            _playerProgressService.PlayerProgress = CreateNewProgress();

        private PlayerProgress CreateNewProgress() =>
            new PlayerProgress();

        public void Exit()
        {
        }
    }
}