using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.Services.Factory.CinemachineFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.HudFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.HeroHandler;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
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
                [typeof(LoadLevelState)] = new LoadLevelState(this, services.Single<IHudFactory>(), services.Single<IHeroFactory>(), services.Single<IHeroHandler>(), services.Single<ICinemachineFactory>(),
                services.Single<IUiFactory>(), services.Single<IInputService>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IPlayerProgressService>()),
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