using Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class CoinSpawner : MonoBehaviour
    {
        private ICoinFactory _coinFactory;

        public void Construct(ICoinFactory coinFactory) =>
            _coinFactory = coinFactory;
        public void Spawn() =>
            _coinFactory.CreateCoin(at: transform.position);
    }
}
