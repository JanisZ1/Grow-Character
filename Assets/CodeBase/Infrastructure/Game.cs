using Assets.CodeBase.Infrastructure.States.GameStates;

namespace Assets.CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner) =>
            StateMachine = new GameStateMachine(coroutineRunner, new SceneLoader(coroutineRunner));
    }
}