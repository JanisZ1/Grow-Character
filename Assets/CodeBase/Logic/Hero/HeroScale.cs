using Assets.CodeBase.Infrastructure.Services.InputService;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroScale : MonoBehaviour
    {
        [SerializeField] private Transform _heroTransform;
        [SerializeField] private float _scaleFactor;

        private IInputService _inputService;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start() =>
            _inputService.MouseButtonDown += AddScale;

        private void OnDestroy() =>
            _inputService.MouseButtonDown -= AddScale;

        private void AddScale() =>
            _heroTransform.localScale += Vector3.one * _scaleFactor;
    }
}
