using Assets.CodeBase.Infrastructure.Services.Factory.CinemachineFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HudFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.HeroHandler;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IStaticDataService _staticData;
        private readonly IHudFactory _hudFactory;
        private readonly IHeroFactory _heroFactory;
        private readonly IHeroHandler _heroHandler;
        private readonly ICinemachineFactory _cinemachineFactory;
        private readonly IUiFactory _uiFactory;
        private readonly IInputService _inputService;

        public LoadLevelState(GameStateMachine gameStateMachine, IStaticDataService staticData, IHudFactory hudFactory, IHeroFactory heroFactory, IHeroHandler heroHandler, ICinemachineFactory cinemachineFactory, IUiFactory uiFactory, IInputService inputService)
        {
            _stateMachine = gameStateMachine;
            _staticData = staticData;
            _hudFactory = hudFactory;
            _heroFactory = heroFactory;
            _heroHandler = heroHandler;
            _cinemachineFactory = cinemachineFactory;
            _uiFactory = uiFactory;
            _inputService = inputService;
        }

        public void Enter(string sceneName) =>
            InitializeLevel();

        private void InitializeLevel()
        {
            _staticData.Load();
            _inputService.StartUpdate();
            InitializeHero();
            InitializeCinemachine();
            _uiFactory.CreateUiRoot();
            _hudFactory.CreateHud();
            EnterLoadProgress();
        }

        private void EnterLoadProgress() =>
            _stateMachine.Enter<LoadProgressState>();

        private void InitializeHero()
        {
            GameObject hero = _heroFactory.CreateHero();
            _heroHandler.Handle(hero);
        }

        private void InitializeCinemachine()
        {
            GameObject cameraRotatePoint = _cinemachineFactory.CreateCameraRotatePoint();
            _cinemachineFactory.CreateVirtualCamera(cameraRotatePoint.transform);
        }

        public void Exit()
        {
        }
    }
}