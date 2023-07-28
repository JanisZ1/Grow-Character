using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Logic;
using Assets.CodeBase.Logic.Hero;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IAssets _assets;
        private readonly IInputService _inputService;
        private readonly IPlayerProgressService _playerProgressService;
        private readonly IShopItemObserver _shopItemObserver;

        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

        public HeroFactory(IAssets assets, IInputService inputService, IPlayerProgressService playerProgressService, IShopItemObserver shopItemObserver)
        {
            _assets = assets;
            _inputService = inputService;
            _playerProgressService = playerProgressService;
            _shopItemObserver = shopItemObserver;
        }

        public GameObject CreateHero()
        {
            GameObject gameObject = InstantiateRegistered(AssetPath.HeroPath);

            gameObject.GetComponent<HeroMove>().Construct(_inputService);
            gameObject.GetComponent<HeroScale>().Construct(_inputService, _playerProgressService, _shopItemObserver);
            gameObject.GetComponent<MoneyEarn>().Construct(_inputService, _playerProgressService, _shopItemObserver);

            return gameObject;
        }
        private GameObject InstantiateRegistered(string assetPath)
        {
            GameObject gameObject = _assets.Instantiate(assetPath);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }
    }
}
