using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.Services.Factory;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class GameStateMachine
    {
        private IExitableState _currentState;

        private Dictionary<Type, IExitableState> _states;

        public GameStateMachine(ICoroutineRunner coroutineRunner, SceneLoader sceneLoader, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, coroutineRunner, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, services.Single<IHeroFactory>(), services.Single<ICinemachineFactory>(), services.Single<IInputService>()),
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