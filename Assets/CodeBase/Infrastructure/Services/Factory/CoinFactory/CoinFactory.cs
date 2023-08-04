using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Logic.CoinLogic;
using Assets.CodeBase.Logic.Spawners.Coin;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory
{
    public class CoinFactory : ICoinFactory
    {
        private readonly IAssets _assets;
        private readonly IPlayerProgressService _playerProgress;
        private readonly IShopItemObserver _shopItemObserver;

        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

        public CoinFactory(IAssets assets, IPlayerProgressService playerProgress, IShopItemObserver shopItemObserver)
        {
            _assets = assets;
            _playerProgress = playerProgress;
            _shopItemObserver = shopItemObserver;
        }

        public CoinSpawner CreateSpawner(Vector3 at)
        {
            GameObject gameObject = InstantiateRegistered(AssetPath.CoinSpawnerPath, at);

            CoinSpawner coinSpawner = gameObject.GetComponent<CoinSpawner>();
            coinSpawner.Construct(this);

            return coinSpawner;
        }

        public GameObject CreateCoin(Vector3 at, Transform parent)
        {
            GameObject gameObject = InstantiateRegistered(AssetPath.CoinPath, parent, at);

            Coin coin = gameObject.GetComponent<Coin>();
            coin.Construct(_playerProgress, _shopItemObserver);
            coin.Value = _playerProgress.Progress.MoneyData.ByClickEarnAmount;

            return gameObject;
        }

        private GameObject InstantiateRegistered(string path, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(path, at);

            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private GameObject InstantiateRegistered(string path, Transform parent, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(path, parent, at);

            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                if (progressReader is ISavedProgress progressWriter)
                    ProgressWriters.Add(progressWriter);

                ProgressReaders.Add(progressReader);
            }
        }

        public void Cleanup()
        {
            ProgressWriters.Clear();
            ProgressReaders.Clear();
        }
    }
}
