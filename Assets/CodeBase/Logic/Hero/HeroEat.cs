using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.Observer.HeroEat;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroEat : MonoBehaviour
    {
        [SerializeField] private HeroAnimator _animator;
        [SerializeField] private AudioSource _eatSound;

        public event Action Eated;

        private IInputService _inputService;
        private IHeroEatObserver _heroEatObserver;
        private bool _animationIsPlaying;

        public void Construct(IInputService inputService, IHeroEatObserver heroEatObserver)
        {
            _inputService = inputService;
            _heroEatObserver = heroEatObserver;
        }

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
            {
                _heroEatObserver.OnEatStarted();
                _animationIsPlaying = true;
            }
        }

        private void StateExited(AnimatorState state)
        {
            if (state == AnimatorState.Eat)
                _animationIsPlaying = false;
        }

        private void MouseButtonDown()
        {
            if (!_animationIsPlaying && !EventSystem.current.IsPointerOverGameObject())
                _animator.PlayEat();
        }

        private void FoodEated()
        {
            _eatSound.Play();
            Eated?.Invoke();
        }
    }

}
