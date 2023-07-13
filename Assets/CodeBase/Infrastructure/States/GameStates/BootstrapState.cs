using Assets.CodeBase.Infrastructure.Services;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class BootstrapState : IState
    {
        private SceneLoader _sceneLoader;
        private AllServices _services;
        private string _sceneName = "Main";

        private GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter() =>
            _sceneLoader.Load(_sceneName, OnLoaded);

        public void Exit()
        {
        }

        private void RegisterServices() =>
            _services.Register(InputService());

        private void OnLoaded() =>
            _stateMachine.Enter<LoadLevelState, string>(_sceneName);

        private IInputService InputService() =>
            new PersonalComputerInputService();
    }
}