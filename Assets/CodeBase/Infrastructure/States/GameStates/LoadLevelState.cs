using Assets.CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private GameStateMachine _stateMachine;
        private readonly IHeroFactory _heroFactory;
        private readonly IInputService _inputService;

        public LoadLevelState(GameStateMachine gameStateMachine, IHeroFactory heroFactory, IInputService inputService)
        {
            _stateMachine = gameStateMachine;
            _heroFactory = heroFactory;
            _inputService = inputService;
        }

        public void Enter(string sceneName) =>
            InitializeLevel();

        private void InitializeLevel()
        {
            _inputService.StartUpdate();
            _heroFactory.CreateHero(Vector3.zero);
        }

        public void Exit()
        {
        }
    }
}