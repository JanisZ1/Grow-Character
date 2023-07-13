using Assets.CodeBase.Infrastructure.States.GameStates;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(gameObject);
        }
    }
}