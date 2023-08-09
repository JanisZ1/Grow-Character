namespace Assets.CodeBase.Logic
{
    public interface IAnimationStateReader
    {
        void ExitedState(int stateHash);
        void EnteredState(int stateHash);
        AnimatorState State { get; }
    }
}
