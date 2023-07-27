using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPlayerProgressService _playerProgressService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPlayerProgressService playerProgressService)
        {
            _gameStateMachine = gameStateMachine;
            _playerProgressService = playerProgressService;
        }

        public void Enter() =>
            _playerProgressService.PlayerProgress = CreateNewProgress();

        private PlayerProgress CreateNewProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress();

            playerProgress.MassData.Mass.Current = 0.1f;
            playerProgress.MassData.MaxMass.Current = 0.5f;
            playerProgress.MassData.Mass.ScaleFactor = 0.001f;

            return playerProgress;
        }

        public void Exit()
        {
        }
    }
}