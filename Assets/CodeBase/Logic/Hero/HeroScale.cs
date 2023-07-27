using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroScale : MonoBehaviour
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
            LoadProgress();

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
        //LoadProgressImitation
        //TODO: Real progress saving and loading
        private void LoadProgress()
        {
            float mass = LoadMassProgress();
            float scaleFactor = LoadScaleFactorProgress();
            float maxMass = LoadMaxMassProgress();

            _heroTransform.localScale = new Vector3(mass, mass, mass);
            _maximumMass = maxMass;
            _scaleFactor = scaleFactor;
        }

        private float LoadScaleFactorProgress() =>
            _playerProgress.PlayerProgress.MassData.Mass.ScaleFactor;

        private float LoadMaxMassProgress() =>
            _playerProgress.PlayerProgress.MassData.MaxMass.Current;

        private float LoadMassProgress() =>
            _playerProgress.PlayerProgress.MassData.Mass.Current;

        private void ChangeMaximumMass(ShopItemData shopItemData) =>
            _maximumMass = shopItemData.MaximumMass;

        private void ChangeScaleFactor(ShopItemData shopItemData) =>
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
            _playerProgress.PlayerProgress.MassData.Mass.Change(_heroTransform.localScale.x);

        private Vector3 MassToChange() =>
            _heroTransform.localScale + Vector3.one * _scaleFactor;

        private Vector3 MaximumMass() =>
            new Vector3(_maximumMass, _maximumMass, _maximumMass);
    }
}
