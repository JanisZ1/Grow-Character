using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPlayerProgressService _playerProgressService;

        public LoadProgressState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService, IPlayerProgressService playerProgressService)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _playerProgressService = playerProgressService;
        }

        public void Enter()
        {
            LoadOrCreateNewProgress();

            EnterLoadLevel();
        }

        private void LoadOrCreateNewProgress()
        {
            _playerProgressService.Progress = _saveLoadService.LoadProgress() ??
                CreateNewProgress();
        }

        private PlayerProgress CreateNewProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress(bootstrapLevel: "Main");

            playerProgress.MassData.Mass.Current = 0.1f;
            playerProgress.MassData.MaxMass.Current = 0.2f;
            playerProgress.MassData.Mass.ScaleFactor = 0.001f;
            playerProgress.MoneyData.ByClickEarnAmount = 0.008f;

            return playerProgress;
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadLevelState, string>(_playerProgressService.Progress.WorldData.Level);

        public void Exit()
        {
        }
    }
}