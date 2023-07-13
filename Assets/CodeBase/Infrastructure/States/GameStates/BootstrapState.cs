using Assets.CodeBase.Infrastructure.Services;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class BootstrapState : IState
    {
        private SceneLoader _sceneLoader;
        private AllServices _services;
        private string _sceneName = "Main";

        private GameStateMachine _stateMachine;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
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
            _services.Register<IInputService>(new InputService(_coroutineRunner));

        private void OnLoaded() =>
            _stateMachine.Enter<LoadLevelState, string>(_sceneName);
    }
}