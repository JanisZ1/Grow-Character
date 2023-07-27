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

        public void CreateSpawner(Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.CoinSpawnerPath);

            gameObject.GetComponent<CoinSpawner>().Construct(this);
        }

        public void CreateCoin(Vector3 at)
        {

        }
    }
}
