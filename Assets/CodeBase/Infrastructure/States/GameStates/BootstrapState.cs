using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.BackgroundSoundObserver;
using Assets.CodeBase.Infrastructure.Services.CoinSpawnerHandler;
using Assets.CodeBase.Infrastructure.Services.CoinSpawnService;
using Assets.CodeBase.Infrastructure.Services.Factory;
using Assets.CodeBase.Infrastructure.Services.Factory.CinemachineFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HeightShowBuilding;
using Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HudFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.HeroHandler;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.Observer.HeroEat;
using Assets.CodeBase.Infrastructure.Services.PlayerLearn;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.Services.WindowService;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class BootstrapState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        private readonly string Bootstrap = "Bootstrap";

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
            _sceneLoader.Load(Bootstrap, OnLoaded);

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            _services.Register<IAssets>(new AssetProvider());
            _services.Register<IStaticDataService>(new StaticDataService());
            _services.Register<IShopItemObserver>(new ShopItemObserver());
            _services.Register<IPlayerProgressService>(new PlayerProgressService());
            _services.Register<IInputService>(new InputService(_coroutineRunner));
            _services.Register<IHeroHandler>(new HeroHandler());
            _services.Register<IBackgroundSoundObserver>(new BackgroundSoundObserver());
            _services.Register<IHeroEatObserver>(new HeroEatObserver());
            _services.Register<IHeightShowBuildingFactory>(new HeightShowBuildingFactory(_services.Single<IAssets>(), _services.Single<IStaticDataService>()));
            _services.Register<ISoundFactory>(new SoundFactory(_services.Single<IAssets>(), _services.Single<IStaticDataService>(), _services.Single<IBackgroundSoundObserver>()));
            _services.Register<IHeroFactory>(new HeroFactory(_services.Single<IAssets>(), _services.Single<IInputService>(), _services.Single<IHeroEatObserver>(), _services.Single<IPlayerProgressService>(), _services.Single<IShopItemObserver>()));
            _services.Register<IUiFactory>(new UiFactory(_services.Single<IAssets>(), _services.Single<IStaticDataService>(), _services.Single<IPlayerProgressService>(), _services.Single<IShopItemObserver>()));
            _services.Register<IPlayerLearnService>(new PlayerLearnService(_services.Single<IUiFactory>()));
            _services.Register<ISaveLoadService>(new SaveLoadService(_services.Single<IPlayerProgressService>(), _services.Single<IHeroFactory>(), _services.Single<IUiFactory>()));
            _services.Register<ICoinSpawnerHandler>(new CoinSpawnerHandler());
            _services.Register<ICoinSpawnService>(new CoinSpawnService(_coroutineRunner, _services.Single<ICoinSpawnerHandler>()));
            _services.Register<ICoinFactory>(new CoinFactory(_services.Single<IAssets>(), _services.Single<IPlayerProgressService>(), _services.Single<IShopItemObserver>()));
            _services.Register<ICinemachineFactory>(new CinemachineFactory(_services.Single<IAssets>(), _services.Single<IHeroHandler>()));
            _services.Register<IWindowService>(new WindowService(_services.Single<IUiFactory>(), _services.Single<IPlayerProgressService>()));
            _services.Register<IHudFactory>(new HudFactory(_services.Single<IAssets>(), _services.Single<IHeroEatObserver>(), _services.Single<IInputService>(), _services.Single<IWindowService>(), _services.Single<IPlayerProgressService>()));
        }

        private void OnLoaded() =>
            _stateMachine.Enter<LoadProgressState>();
    }
}