using Assets.CodeBase.Infrastructure.Services.InputService;
using System;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroEat : MonoBehaviour
    {
        [SerializeField] private HeroAnimator _animator;

        public event Action Eated;

        private IInputService _inputService;
        private bool _animationIsPlaying;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start()
        {
            _animator.Eated += FoodEated;
            _animator.StateEntered += StateEntered;
            _animator.StateExited += StateExited;
            _inputService.MouseButtonDown += MouseButtonDown;
        }

        private void OnDestroy()
        {
            _inputService.MouseButtonDown -= MouseButtonDown;
            _animator.StateEntered -= StateEntered;
            _animator.StateExited -= StateExited;
            _animator.Eated -= FoodEated;
        }

        private void StateEntered(AnimatorState state)
        {
            if (state == AnimatorState.Eat)
                _animationIsPlaying = true;
        }

        private void StateExited(AnimatorState state)
        {
            if (state == AnimatorState.Eat)
                _animationIsPlaying = false;
        }

        private void MouseButtonDown()
        {
            if (!_animationIsPlaying)
                _animator.PlayEat();
        }

        private void FoodEated() =>
            Eated?.Invoke();
    }
}
