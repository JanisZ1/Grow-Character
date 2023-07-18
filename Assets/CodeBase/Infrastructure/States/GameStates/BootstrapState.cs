using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Factory;

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

        private void RegisterServices()
        {
            _services.Register<IAssets>(new AssetProvider());
            _services.Register<IInputService>(new InputService(_coroutineRunner));
            _services.Register<IHeroHandler>(new HeroHandler());
            _services.Register<IHeroFactory>(new HeroFactory(_services.Single<IAssets>(), _services.Single<IInputService>()));
            _services.Register<ICinemachineFactory>(new CinemachineFactory(_services.Single<IAssets>(), _services.Single<IHeroHandler>()));
        }

        private void OnLoaded() =>
            _stateMachine.Enter<LoadLevelState, string>(_sceneName);
    }
}