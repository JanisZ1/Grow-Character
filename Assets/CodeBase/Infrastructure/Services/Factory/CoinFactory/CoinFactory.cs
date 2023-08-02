using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Logic.CoinLogic;
using Assets.CodeBase.Logic.Spawners.Coin;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory
{
    public class CoinFactory : ICoinFactory
    {
        private readonly IAssets _assets;
        private readonly IPlayerProgressService _playerProgress;
        private readonly IShopItemObserver _shopItemObserver;

        public CoinFactory(IAssets assets, IPlayerProgressService playerProgress, IShopItemObserver shopItemObserver)
        {
            _assets = assets;
            _playerProgress = playerProgress;
            _shopItemObserver = shopItemObserver;
        }

        public CoinSpawner CreateSpawner(Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.CoinSpawnerPath, at);

            CoinSpawner coinSpawner = gameObject.GetComponent<CoinSpawner>();
            coinSpawner.Construct(this);

            return coinSpawner;
        }

        public GameObject CreateCoin(Vector3 at, Transform parent)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.CoinPath, parent, at);

            Coin coin = gameObject.GetComponent<Coin>();
            coin.Construct(_playerProgress, _shopItemObserver);
            coin.Value = _playerProgress.Progress.MoneyData.ByClickEarnAmount;

            return gameObject;
        }
    }
}
