﻿using Assets.CodeBase.Infrastructure.Services;
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
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class GameStateMachine
    {
        private IExitableState _currentState;

        private readonly Dictionary<Type, IExitableState> _states;

        public GameStateMachine(ICoroutineRunner coroutineRunner, SceneLoader sceneLoader, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, coroutineRunner, sceneLoader, services),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<ISaveLoadService>(), services.Single<IPlayerProgressService>()),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, services.Single<IHeightShowBuildingFactory>(), services.Single<ISoundFactory>(), coroutineRunner, services.Single<IPlayerProgressService>(),
                services.Single<ISaveLoadService>(), services.Single<ICoinSpawnService>(), services.Single<ICoinSpawnerHandler>(),
                services.Single<ICoinFactory>(), services.Single<IStaticDataService>(), services.Single<IHudFactory>(), services.Single<IHeroFactory>(),
                services.Single<IHeroHandler>(), services.Single<ICinemachineFactory>(),
                services.Single<IUiFactory>(), services.Single<IInputService>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
          _states[typeof(TState)] as TState;
    }
}