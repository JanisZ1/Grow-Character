using Assets.CodeBase.Infrastructure.Services.CoinSpawnerHandler;
using Assets.CodeBase.Infrastructure.Services.CoinSpawnService;
using Assets.CodeBase.Infrastructure.Services.Factory;
using Assets.CodeBase.Infrastructure.Services.Factory.CinemachineFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HudFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.HeroHandler;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using Assets.CodeBase.Logic.Spawners.Coin;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ISoundFactory _soundFactory;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IPlayerProgressService _playerProgress;
        private readonly ISaveLoadService _saveLoadService;
        private readonly ICoinSpawnService _coinSpawnService;
        private readonly ICoinSpawnerHandler _coinSpawnerHandler;
        private readonly ICoinFactory _coinFactory;
        private readonly IStaticDataService _staticData;
        private readonly IHudFactory _hudFactory;
        private readonly IHeroFactory _heroFactory;
        private readonly IHeroHandler _heroHandler;
        private readonly ICinemachineFactory _cinemachineFactory;
        private readonly IUiFactory _uiFactory;
        private readonly IInputService _inputService;
        private ProgressSaver _progressSaver;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, ISoundFactory soundFactory, ICoroutineRunner coroutineRunner, IPlayerProgressService playerProgress, ISaveLoadService saveLoadService, ICoinSpawnService coinSpawnService, ICoinSpawnerHandler coinSpawnerHandler, ICoinFactory coinFactory, IStaticDataService staticData, IHudFactory hudFactory, IHeroFactory heroFactory, IHeroHandler heroHandler, ICinemachineFactory cinemachineFactory, IUiFactory uiFactory, IInputService inputService)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _soundFactory = soundFactory;
            _coroutineRunner = coroutineRunner;
            _playerProgress = playerProgress;
            _saveLoadService = saveLoadService;
            _coinSpawnService = coinSpawnService;
            _coinSpawnerHandler = coinSpawnerHandler;
            _coinFactory = coinFactory;
            _staticData = staticData;
            _hudFactory = hudFactory;
            _heroFactory = heroFactory;
            _heroHandler = heroHandler;
            _cinemachineFactory = cinemachineFactory;
            _uiFactory = uiFactory;
            _inputService = inputService;
        }

        public void Enter(string sceneName)
        {
            _heroFactory.Cleanup();
            _coinFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            _staticData.Load();
            LevelStaticData levelStaticData = _staticData.ForLevel(SceneManager.GetActiveScene().name);

            StartSoundSwitch();

            _inputService.StartUpdate();
            InitializeHero();
            InitializeCinemachine();

            HandleCoinSpawners(levelStaticData);
            _coinSpawnService.StartSpawn();
            _uiFactory.CreateUiRoot();
            _hudFactory.CreateHud();
            InformProgressReaders();
            StartSaveProcess();
            EnterGameLoop();
        }

        private void StartSoundSwitch()
        {
            _soundFactory.CreateSoundSwitcher();

            SoundSwitcher soundSwitcher = _soundFactory.SoundSwitcher.GetComponent<SoundSwitcher>();
            soundSwitcher.StartSoundSwitch();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _heroFactory.ProgressReaders)
                progressReader.LoadProgress(_playerProgress.Progress);

            foreach (ISavedProgressReader progressReader in _coinFactory.ProgressReaders)
                progressReader.LoadProgress(_playerProgress.Progress);
        }

        private void StartSaveProcess()
        {
            _progressSaver = new ProgressSaver(_coroutineRunner, _saveLoadService);
            _progressSaver.StartProcess();
        }

        private void HandleCoinSpawners(LevelStaticData levelStaticData)
        {
            List<CoinSpawner> coinSpawners = new List<CoinSpawner>();

            foreach (CoinSpawnPointData coinSpawnerData in levelStaticData.CoinSpawners)
            {
                CoinSpawner coinSpawner = _coinFactory.CreateSpawner(coinSpawnerData.Position);
                coinSpawners.Add(coinSpawner);
            }
            _coinSpawnerHandler.CoinSpawners = coinSpawners;
        }

        private void EnterGameLoop() =>
            _stateMachine.Enter<GameLoopState>();

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