using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Factory.CinemachineFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HudFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.HeroHandler;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.Services.WindowService;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class BootstrapState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        private readonly string _sceneName = "Main";

        private readonly GameStateMachine _stateMachine;
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
            _services.Register<IStaticDataService>(new StaticDataService());
            _services.Register<IPlayerProgressService>(new PlayerProgressService());
            _services.Register<IInputService>(new InputService(_coroutineRunner));
            _services.Register<IHeroHandler>(new HeroHandler());
            _services.Register<IHeroFactory>(new HeroFactory(_services.Single<IAssets>(), _services.Single<IInputService>(), _services.Single<IPlayerProgressService>()));
            _services.Register<ICinemachineFactory>(new CinemachineFactory(_services.Single<IAssets>(), _services.Single<IHeroHandler>()));
            _services.Register<IUiFactory>(new UiFactory(_services.Single<IAssets>()));
            _services.Register<IWindowService>(new WindowService(_services.Single<IUiFactory>()));
            _services.Register<IHudFactory>(new HudFactory(_services.Single<IAssets>(), _services.Single<IInputService>(), _services.Single<IWindowService>(), _services.Single<IPlayerProgressService>()));
        }

        private void OnLoaded() =>
            _stateMachine.Enter<LoadLevelState, string>(_sceneName);
    }
}