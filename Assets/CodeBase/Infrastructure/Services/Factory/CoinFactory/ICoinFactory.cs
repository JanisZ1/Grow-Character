using Assets.CodeBase.Logic.Spawners.Coin;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory
{
    public interface ICoinFactory : IService
    {
        CoinSpawner CreateSpawner(Vector3 at);
        void CreateCoin(Vector3 at);
    }
}
