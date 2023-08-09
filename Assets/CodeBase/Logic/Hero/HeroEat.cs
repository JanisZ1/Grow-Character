using Assets.CodeBase.Infrastructure.Services.InputService;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroEat : MonoBehaviour
    {
        [SerializeField] private HeroAnimator _animator;

        private IInputService _inputService;
        private bool _animationIsPlaying;

        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        private void Start() => 
            _inputService.MouseButtonDown += MouseButtonDown;

        private void OnDestroy() => 
            _inputService.MouseButtonDown -= MouseButtonDown;

        private void MouseButtonDown()
        {
            if (!_animationIsPlaying)
                StartCoroutine(PlayAnimation());
        }

        private IEnumerator PlayAnimation()
        {
            _animator.PlayEat();
            _animationIsPlaying = true;

            yield return new WaitForSeconds(_animator.EatLength);

            _animationIsPlaying = false;
        }
    }
}
