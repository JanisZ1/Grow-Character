using System;
using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayEat() => _animator.SetTrigger("Eat");

    public float EatLength { get; private set; } = 1f;

    public event Action Eated;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _animator.SetFloat("Horizontal", horizontalInput);
        _animator.SetFloat("Vertical", verticalInput);
    }

    public void InvokeEatEvent() =>
        Eated?.Invoke();
}
