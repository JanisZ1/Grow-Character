using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Logic.Spawners.Coin;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory
{
    public class CoinFactory : ICoinFactory
    {
        private readonly IAssets _assets;

        public CoinFactory(IAssets assets) =>
            _assets = assets;

        public CoinSpawner CreateSpawner(Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.CoinSpawnerPath, at);

            CoinSpawner coinSpawner = gameObject.GetComponent<CoinSpawner>();
            coinSpawner.Construct(this);

            return coinSpawner;
        }

        public GameObject CreateCoin(Vector3 at, Transform parent) =>
            _assets.Instantiate(AssetPath.CoinPath, parent, at);
    }
}
