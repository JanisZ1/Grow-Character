using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroScale : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private Transform _heroTransform;

        private IInputService _inputService;
        private IPlayerProgressService _playerProgress;
        private IShopItemObserver _shopItemObserver;

        private float _maximumMass;
        private float _scaleFactor;

        public void Construct(IInputService inputService, IPlayerProgressService playerProgress, IShopItemObserver shopItemObserver)
        {
            _inputService = inputService;
            _playerProgress = playerProgress;
            _shopItemObserver = shopItemObserver;
        }

        private void Start()
        {
            _shopItemObserver.Buyed += ChangeMaximumMass;
            _shopItemObserver.Buyed += ChangeScaleFactor;
            _inputService.MouseButtonDown += AddScale;
        }

        private void OnDestroy()
        {
            _inputService.MouseButtonDown -= AddScale;
            _shopItemObserver.Buyed -= ChangeMaximumMass;
            _shopItemObserver.Buyed -= ChangeScaleFactor;
        }

        private void ChangeMaximumMass(Infrastructure.StaticData.ShopItemData shopItemData)
        {
            float maximumMass = shopItemData.MaximumMass;

            _maximumMass = maximumMass;
            _playerProgress.Progress.MassData.MaxMass.Change(maximumMass);
        }

        private void ChangeScaleFactor(Infrastructure.StaticData.ShopItemData shopItemData) =>
            _scaleFactor = shopItemData.Calories;

        private void AddScale()
        {
            Vector3 massToChange = MassToChange();

            if (massToChange.x < _maximumMass)
            {
                _heroTransform.localScale = massToChange;
                SaveMassChange();
            }
            if (_heroTransform.localScale.x > _maximumMass)
            {
                _heroTransform.localScale = MaximumMass();
                SaveMassChange();
            }
        }

        private void SaveMassChange() =>
            _playerProgress.Progress.MassData.Mass.Change(_heroTransform.localScale.x);

        private Vector3 MassToChange() =>
            _heroTransform.localScale + Vector3.one * _scaleFactor;

        private Vector3 MaximumMass() =>
            new Vector3(_maximumMass, _maximumMass, _maximumMass);

        public void SaveProgress(PlayerProgress progress)
        {
            progress.MassData.Mass.Current = _heroTransform.localScale.x;
            progress.MassData.Mass.ScaleFactor = _scaleFactor;
            progress.MassData.MaxMass.Current = _maximumMass;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            float mass = progress.MassData.Mass.Current;
            float scaleFactor = progress.MassData.Mass.ScaleFactor;
            float maxMass = progress.MassData.MaxMass.Current;

            _heroTransform.localScale = new Vector3(mass, mass, mass);
            _maximumMass = maxMass;
            _scaleFactor = scaleFactor;
        }
    }
}
