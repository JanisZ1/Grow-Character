using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class GameStateMachine
    {
        private IExitableState _currentState;

        private Dictionary<Type, IExitableState> _states;

        public GameStateMachine(ICoroutineRunner coroutineRunner, SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this,sceneLoader);
        }

        public void Enter<TState>() where TState : IExitableState
        {
        }
    }
}