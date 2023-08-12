using Assets.CodeBase.Logic;
using System;
using UnityEngine;

public class HeroAnimator : MonoBehaviour, IAnimationStateReader
{
    [SerializeField] private Animator _animator;

    private readonly int _eatStateHash = Animator.StringToHash("Eat");

    public event Action Eated;

    public event Action<AnimatorState> StateEntered;
    public event Action<AnimatorState> StateExited;

    public AnimatorState State { get; private set; }

    public void PlayEat() => _animator.SetTrigger("Eat");

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _animator.SetFloat("Horizontal", horizontalInput);
        _animator.SetFloat("Vertical", verticalInput);
    }

    public void InvokeEatEvent() => 
        Eated?.Invoke();

    public void ExitedState(int stateHash)
    {
        State = StateFor(stateHash);
        StateExited?.Invoke(State);
    }

    public void EnteredState(int stateHash)
    {
        State = StateFor(stateHash);
        StateEntered?.Invoke(State);
    }

    private AnimatorState StateFor(int stateHash)
    {
        AnimatorState state;
        if (stateHash == _eatStateHash)
        {
            state = AnimatorState.Eat;
        }
        else
        {
            state = AnimatorState.Unknown;
        }

        return state;
    }
}
