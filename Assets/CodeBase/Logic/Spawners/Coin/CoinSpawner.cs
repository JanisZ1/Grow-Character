using Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory;
using UnityEngine;

namespace Assets.CodeBase.Logic.Spawners.Coin
{
    public class CoinSpawner : MonoBehaviour
    {
        private ICoinFactory _coinFactory;

        public bool Spawned { get; set; }

        public void Construct(ICoinFactory coinFactory) =>
            _coinFactory = coinFactory;

        public void Spawn()
        {
            _coinFactory.CreateCoin(at: transform.position, transform);
            Spawned = true;
        }
    }
}
