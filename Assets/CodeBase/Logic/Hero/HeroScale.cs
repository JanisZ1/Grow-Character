using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroScale : MonoBehaviour
    {
        [SerializeField] private Transform _heroTransform;
        [SerializeField] private float _scaleFactor;

        private IInputService _inputService;
        private IPlayerProgressService _playerProgress;

        public void Construct(IInputService inputService, IPlayerProgressService playerProgress)
        {
            _inputService = inputService;
            _playerProgress = playerProgress;
        }

        private void Start() =>
            _inputService.MouseButtonDown += AddScale;

        private void OnDestroy() =>
            _inputService.MouseButtonDown -= AddScale;

        private void AddScale()
        {
            _heroTransform.localScale += Vector3.one * _scaleFactor;
            _playerProgress.PlayerProgress.MassData.Mass.Change(_heroTransform.localScale.x);
        }
    }
}
