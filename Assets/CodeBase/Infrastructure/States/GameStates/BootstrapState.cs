namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class BootstrapState : IState
    {
        private SceneLoader _sceneLoader;

        private string _sceneName = "Main";

        private GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() =>
            _sceneLoader.Load(_sceneName, OnLoaded);

        private void OnLoaded() =>
            _stateMachine.Enter<LoadLevelState, string>(_sceneName);

        public void Exit()
        {
        }
    }
}